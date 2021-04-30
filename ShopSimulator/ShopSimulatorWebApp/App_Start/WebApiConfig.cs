﻿using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using ShopSimulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShopSimulatorWebApp
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

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            builder.EntitySet<SupplierEntity>("Suppliers");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}
