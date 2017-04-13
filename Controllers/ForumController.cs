using AngularForum.Models;
using AngularForum.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AngularForum.Controllers
{
    
    public class ForumController : ApiController
    {
        
        DataAccessContext context = new DataAccessContext();

        //Get All Forum
        [HttpGet]
        public IEnumerable<ForumViewModel> GetAllForum()
        {           
            var data = context.Forum.ToList().OrderBy(x=>x.Subject);
            var result = data.Select(x => new ForumViewModel()
            {                
                ForumID = x.ForumID,
                Subject = x.Subject,
                CategoryID = x.CategoryID,
                PostedBy = x.PostedBy,
                Description = x.Description,
                ForumDate = x.ForumDate
        });
            return result.ToList();
        }

        [HttpGet]
        public IEnumerable<ForumViewModel> GetAllForum(int Id)
        {
            var data = context.Forum.ToList().Where(x => x.CategoryID == Id).OrderBy(x => x.Subject);
            var result = data.Select(x => new ForumViewModel()
            {
                ForumID = x.ForumID,
                Subject = x.Subject,
                CategoryID = x.CategoryID,
                PostedBy = x.PostedBy,
                Description = x.Description,
                ForumDate = x.ForumDate
            });
            return result.ToList();
        }

        //Get All Forum
        [HttpGet]
        public ForumViewModel GetForum(int Id)
        {
            var data = context.Forum.Where(x => x.ForumID == Id).FirstOrDefault();
            if (data != null)
            {
                ForumViewModel forum = new ForumViewModel();
                forum.ForumID = data.ForumID;
                forum.Subject = data.Subject;
                forum.CategoryID = data.CategoryID;
                forum.PostedBy = data.PostedBy;
                forum.Description = data.Description;

                return forum;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        //Add new forum

        [HttpPost]
        public HttpResponseMessage AddForum(ForumViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ForumModel forum = new ForumModel();
                    forum.Subject = model.Subject;
                    forum.CategoryID = model.CategoryID;
                    forum.Description = model.Description;
                    forum.PostedBy = model.PostedBy;
                    forum.ForumDate = DateTime.Now;

                    context.Forum.Add(forum);
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

        //Update the forum

        [HttpPut]
        public HttpResponseMessage UpdateForum(ForumViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ForumModel forum = new ForumModel();
                    forum.ForumID = model.ForumID;
                    forum.Subject = model.Subject;
                    forum.CategoryID = model.CategoryID;
                    forum.PostedBy = model.PostedBy;
                    forum.Description = model.Description;
                    forum.ForumDate = DateTime.Now;

                    context.Entry(forum).State = System.Data.Entity.EntityState.Modified;
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
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

        //Delete the forum

        [HttpDelete]
        public HttpResponseMessage DeleteForum(int Id)
        {
            ForumModel forum = new ForumModel();
            forum = context.Forum.Find(Id);
            if (forum != null)
            {
                context.Forum.Remove(forum);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
            }
        }
    }
}
