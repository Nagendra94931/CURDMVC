namespace CURDMVC.RouteServices
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            // Default route
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            // Login 
            endpoints.MapControllerRoute(
                name: "Login",
                pattern: "User/Login",
                defaults: new { controller = "User", action = "Login" });


            // Custom route example
            endpoints.MapControllerRoute(
                name: "productroute",
                pattern: "items/{id}",
                defaults: new { controller = "Product", action = "Details" });
        }
    }
}
