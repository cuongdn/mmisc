using System.Web.Mvc;
using Blogging.Business.Edit;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {

            var abc = QuestionEdit.New();
            WriteLine(abc.Title);

            //var uow = UnitOfWorkFactory.Get();
            //var uow2 = UnitOfWorkFactory.Get();

            //WriteLine(uow);
            //WriteLine(uow2);
            //var repo = new QuestionRepository(uow);

            //var question = QuestionEditModel.Get(1);
            //Print(question);

            //question.Title = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            //question.Answers[0].Description = "aabb" + DateTime.Now.Millisecond;
            //question.Answers[1].Description = "aabb" + DateTime.Now.Millisecond;
            ////question.Answers[2].IsDelete = true;
            //question.Upsert(true);

            //question = QuestionEditModel.Get(1);
            //Print(question);

            //return uow.Equals(uow2) ? bool.TrueString : bool.FalseString;
            return "";
        }

        private void Print(QuestionEdit questionEdit)
        {
            WriteLine(questionEdit.Id);
            WriteLine(questionEdit.Title);
            WriteLine("Children: " + questionEdit.Answers.Count);
            foreach (var item in questionEdit.Answers)
            {
                WriteLine(item.Id + " " + item.Description);
            }
        }

        private void WriteLine(object input)
        {
            Response.Write(input);
            NewLine();
        }

        private void NewLine()
        {
            Response.Write("<br>");
        }
    }
}