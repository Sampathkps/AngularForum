using AngularForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularForum.Controllers
{
    public class CategoryController : ApiController
    {
        DataAccessContext context = new DataAccessContext();

        //Get All Category
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCategory()
        {

            var data = context.Category.ToList().OrderBy(x => x.Category);
            var result = data.Select(x => new CategoryModel()
            {
                CategoryID = x.CategoryID,
                Category = x.Category
            });
            return result.ToList();
        }

        //Add new Category

        [HttpPost]
        public HttpResponseMessage AddCategory(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryModel category = new CategoryModel();
                    category.Category = model.Category;

                    context.Category.Add(category);
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }
    }
}
