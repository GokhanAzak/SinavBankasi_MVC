using Microsoft.Ajax.Utilities;
using SinavBankasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinavBankasi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var _ctx = new DbExamsEntities5();
            ViewBag.Tests = _ctx.Test.Where(x => x.IsActive == true).Select(x => new { x.TestId, x.TestName }).ToList();

            SessionModel _model = null;


            if (Session["SessionModel"] == null)
            {
                _model = new SessionModel();
            }
            else
            {
                _model = (SessionModel)Session["SessionModel"];
            }


            return View(_model);
        }
        public ActionResult Instruction(SessionModel model)
        {
            if (model != null)
            {
                var _ctx = new DbExamsEntities5();
                var test = _ctx.Test.Where(x => x.IsActive == true && x.TestId == model.TestId).FirstOrDefault();

                if (test != null)
                {
                    ViewBag.TestName = test.TestName;
                    ViewBag.TestDescription = test.Description;

                    ViewBag.Duration = test.DurationInMinute;
                }

            }


            return View(model);

        }


        public ActionResult Register(SessionModel model)
        {
            if (model != null)
            {
                Session["SessionModel"] = model;
            }

            if (model == null)
            {
                return RedirectToAction("Index");

            }

            if (model == null || string.IsNullOrEmpty(model.UserName) || model.TestId < 1)
            {
                TempData["message"] = "Geçersiz kayıt ayrıntıları.Lütfen tekrar deneyin";
                return RedirectToAction("Index");

            }
            var _ctx = new DbExamsEntities5();
            Student _user = _ctx.Student.Where(x => x.StudentName.Equals(model.UserName, StringComparison.InvariantCultureIgnoreCase)
                && x.StudentSurName.Equals(model.UserSurName, StringComparison.InvariantCultureIgnoreCase)
                && ((string.IsNullOrEmpty(model.Mail) && string.IsNullOrEmpty(x.Email)) || (x.Email == model.Mail))
                && ((model.Phone == 0 && (x.Phone == null || x.Phone == 0)) || (x.Phone == model.Phone))).FirstOrDefault();

            if (_user == null)
            {
                _user = new Student()
                {
                    StudentName = model.UserName,
                    StudentSurName = model.UserSurName,
                    Email = model.Mail,
                    Phone = model.Phone,
                    EntryDate = DateTime.UtcNow,
                    AccessLevel=100

                };
                _ctx.Student.Add(_user);
                _ctx.SaveChanges();

            }
            Registration registration = _ctx.Registration.Where(x => x.StudentId == _user.StudentId
            && x.TestId == model.TestId
            && x.TokenExpireTime > DateTime.UtcNow).FirstOrDefault();
            if (registration != null)
            {
                Session["TOKEN"] = registration.Token;
                Session["TOKENEXPIRE"] = registration.TokenExpireTime;
            }
            else
            {
                Test test = _ctx.Test.Where(x => x.IsActive == true && x.TestId == model.TestId).FirstOrDefault();
                if (test != null)
                {

                    Registration newRegistation = new Registration()
                    {
                        RegistrationDate = DateTime.UtcNow,
                        TestId = test.TestId,
                        Token = Guid.NewGuid().ToString(),
                        TokenExpireTime = DateTime.UtcNow.AddMinutes((double)test.DurationInMinute)
                    };
                    _ctx.Student.Add(_user);
                    _ctx.Registration.Add(newRegistation);
                    _ctx.SaveChanges();
                    Session["TOKEN"] = registration.Token;
                    Session["TOKENEXPIRE"] = registration.TokenExpireTime;
                }
            }

            return RedirectToAction("EvalPagec", new { @token = Session["TOKEN"] });
        }
        public ActionResult EvalPagec(Guid? token, int? qno)
        {


            if (token == null)
            {
                TempData["message"] = "Bir belirteci geçersiz kıldınız lütfen kayıt olun ve tekrar deneyin";
                return RedirectToAction("Index");
            }


            var _ctx = new DbExamsEntities5();


            //var registration = _ctx.Registrations.Where(x => x.Token.Equals(token)).FirstOrDefault();
            var registration = _ctx.Registration.FirstOrDefault(x => x.Token.Equals(token));

            if (registration == null)
            {
                TempData["message"] = "Bu belirteç geçersiz";
                return RedirectToAction("Index");

            }
            if (!(registration.TokenExpireTime < DateTime.UtcNow))
            {
                if (qno.GetValueOrDefault() < 1)
                {
                    qno = 1;
                }

                var testQuestionId = _ctx.TestXQuestion.Where(x => x.TestId == registration.TestId && x.QuestionNumber == qno)
                    .Select(x => x.TestId).FirstOrDefault();
                if (testQuestionId > 0)
                {
                    var _model = _ctx.TestXQuestion.Where(x => x.TestId == testQuestionId)
                        .Select(x => new QuestionModel()
                        {
                            QuestionType = x.Question.QuestionType,
                            QuestionNumber = (int)x.QuestionNumber,
                            Question = x.Question.QuestionText,
                            Point = (int)x.Question.Points,
                            TestId = (int)x.TestId,
                            TestName = x.Test.TestName,
                            Options = x.Question.Choice.Where(y => y.IsActive == true).Select(y => new QXQModel()
                            {
                                ChoiceId = y.ChoiceId,
                                Label = y.Label,

                            }).ToList()

                        }).FirstOrDefault();
                    var savedAnswers = _ctx.TestXPaper.Where(x => x.TestXQuestionId == testQuestionId && x.RegistrationId == registration.TestId && x.Choice.IsActive == true)
                        .Select(x => new { x.ChoiceId, x.Answer }).ToList();
                    foreach (var savedAnswer in savedAnswers)
                    {
                        _model.Options.Where(x => x.ChoiceId == savedAnswer.ChoiceId).FirstOrDefault().Answer = savedAnswer.Answer;
                    }





                    _model.TotalQuestionInset = _ctx.TestXQuestion.Where(x => x.Question.IsActive == true && x.TestId == registration.TestId).Count();
                    return View(_model);

                }
                else
                {
                    return View("Error");
                }

            }
            TempData["message"] = "Sınav süresi şu tarihte sona ermiştir:" + registration.TokenExpireTime.ToString();
            return RedirectToAction("Index");



        }
        [HttpPost]
        public ActionResult PostAnswer(AnswerModel choices)
        {
            var _ctx = new DbExamsEntities5();

            var registration = _ctx.Registration.Where(x => x.Equals(choices.Token)).FirstOrDefault();
            if (registration == null)
            {
                TempData["message"] = "bu belirteç geçersizdir";
                return RedirectToAction("Index");
            }
            if (registration.TokenExpireTime < DateTime.UtcNow)
            {
                TempData["message"] = "Sınav süresi dolmuştur" + registration.TokenExpireTime.ToString();
                return RedirectToAction("Index");

            }
            var testQuestioninfo = _ctx.TestXQuestion.Where(x => x.TestId == registration.TestId
            && x.QuestionNumber == choices.QuestionId).Select(x => new
            {
                TQId = x.TestId,
                QT = x.Question.QuestionType,
                QID = x.TestId,
                POİNT = (decimal)x.Question.Points
            }).FirstOrDefault();

            if (testQuestioninfo != null)
            {
                if (choices.UserChoices.Count > 1)
                {
                    var allPointValueOfChoice =
                         (
                         from a in _ctx.Choice.Where(x => x.IsActive.Value)
                         join b in choices.UserSelectId on a.ChoiceId equals b
                         select new { a.ChoiceId, Points = (decimal)a.Points }).AsEnumerable()
                         .Select(x => new TestXPaper()
                         {
                             RegistrationId = registration.TestId,
                             TestXQuestionId = testQuestioninfo.QID,
                             ChoiceId = x.ChoiceId,
                             Answer = "CHECKED",
                             MarkScored = (int)Math.Floor((testQuestioninfo.POİNT / 100.00M) * x.Points)
                         }
                         ).ToList();
                    _ctx.TestXPaper.AddRange(allPointValueOfChoice);
                }
                else
                {
                    _ctx.TestXPaper.Add(new TestXPaper()
                    {
                        RegistrationId = registration.TestId,
                        TestXQuestionId = testQuestioninfo.QID,
                        ChoiceId = choices.UserChoices.FirstOrDefault().ChoiceId,
                        MarkScored = 1,
                        Answer = choices.Answer
                    });
                }
                _ctx.SaveChanges();
            }
            var nextQuestionNumber = 1;
            if (choices.Direction.Equals("forward", StringComparison.CurrentCultureIgnoreCase))
            {
                nextQuestionNumber = (int)_ctx.TestXQuestion.Where(x => x.TestId == choices.TestId
                && x.QuestionNumber > choices.QuestionId)
                .OrderBy(x => x.QuestionNumber).Take(1).Select(x => x.QuestionNumber).FirstOrDefault();
            }
            else
            {
                nextQuestionNumber = (int)_ctx.TestXQuestion.Where(x => x.TestId == choices.TestId
               && x.QuestionNumber > choices.QuestionId)
               .OrderByDescending(x => x.QuestionNumber).Take(1).Select(x => x.QuestionNumber).FirstOrDefault();
            }
            if (nextQuestionNumber < 1)
            {
                nextQuestionNumber = 1;
            }

            return RedirectToAction("EvalPagec", new
            {
                @token = Session["TOKEN"],
                @qno = nextQuestionNumber
            });
        }



        public ActionResult HomePagec()
        {
            return View();
        }
    }
}