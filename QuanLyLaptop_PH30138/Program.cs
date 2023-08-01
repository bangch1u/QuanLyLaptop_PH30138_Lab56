using QuanLyLaptop_PH30138.View;
namespace QuanLyLaptop_PH30138
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new fQLyLaptop());
            //Scaffold-DbContext 'Data Source=BANGCHIU105\SQLEXPRESS01;Initial Catalog=lab56;Integrated Security=True ;TrustServerCertificate=true' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context DBContext -Contextdir Context -DataAnnotations -Force

        }
    }
}