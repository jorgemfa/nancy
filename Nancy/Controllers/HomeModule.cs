using Nancy;
using NancyMS.Model;
using Nancy.ModelBinding;
using Nancy.Validation;
using System.Threading.Tasks;

namespace NancyMS.Controllers
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello World, it's Nancy on .NET Core"); 

            Get("/test/{name}", args => new Person() { Name = args.name });

            Post("/person", async (args,_) =>
            {
                Person model = this.Bind();
                var result = this.Validate(model);

                await Task.Delay(8000);
                if (!result.IsValid)
                {
                    return Response.AsJson(result, HttpStatusCode.UnprocessableEntity);
                    //return 422;
                }

                return 200;
            });
        }

    }
}
