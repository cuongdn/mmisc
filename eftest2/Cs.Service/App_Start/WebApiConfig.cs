using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Cs.DbModel.Entities;

namespace Cs.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ODataConventionModelBuilder();
            var ciType = builder.EntitySet<CourseInstructor>("CourseInstructor");
            ciType.EntityType.HasKey(x => x.InstructorId);
            ciType.EntityType.HasKey(x => x.CourseId);

            builder.EntitySet<Course>("Courses");
            builder.EntitySet<Enrollment>("Enrollments");
            var students = builder.EntitySet<Student>("Students");
            var student = students.EntityType;
            student.HasKey(x => x.Id);
            student.Property(x => x.FirstMidName);
            student.Property(x => x.LastName);
            student.Property(x => x.EnrollmentDate);

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
