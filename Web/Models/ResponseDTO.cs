﻿namespace Web.Models
{
    public class ResponseDTO
    {
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
