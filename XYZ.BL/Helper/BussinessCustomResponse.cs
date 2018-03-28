namespace XYZ.BL.Helper
{
    public class BussinessCustomResponse<T>
    {
        public T response { get; set; }
        public bool Success { get; set; } = true;
        public string ErrorMsg { get; set; }

    }
}