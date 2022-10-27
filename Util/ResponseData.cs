namespace EmployeeManagement.Util
{
    public class ResponseData<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public int statuscode { get; set; }
        public int totalcount { get; set; }
        public ResponseData(T _data, bool _success, string _message, int _statuscode)
        {
            data = _data;
            success = _success;
            message = _message;
            statuscode = _statuscode;
        }
        public ResponseData(T _data, bool _success, string _message, int _statuscode, int _totalcount)
        {
            data = _data;
            success = _success;
            message = _message;
            statuscode = _statuscode;
            totalcount = _totalcount;
        }
    }

    public class ResponseData
    {
        public object data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public int statuscode { get; set; }
        public int id { get; set; }
        public int totalcount { get; set; }
        public ResponseData(bool _success, string _message, int _statuscode)
        {
            success = _success;
            message = _message;
            statuscode = _statuscode;
        }

        public ResponseData(int _id, bool _success, string _message, int _statuscode)
        {
            id = _id;
            success = _success;
            message = _message;
            statuscode = _statuscode;
        }
        public ResponseData(object _data, bool _success, string _message, int _statuscode)
        {
            data = _data;
            success = _success;
            message = _message;
            statuscode = _statuscode;
        }
        public ResponseData(object _data, bool _success, string _message, int _statuscode, int _totalcount)
        {
            data = _data;
            success = _success;
            message = _message;
            statuscode = _statuscode;
            totalcount = _totalcount;
        }
    }
}
