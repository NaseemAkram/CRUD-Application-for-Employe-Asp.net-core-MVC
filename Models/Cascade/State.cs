namespace CRUD_Application_Asp.net_core_MVC.Models.Cascade
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }


    }
}
