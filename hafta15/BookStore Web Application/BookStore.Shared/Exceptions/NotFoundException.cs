﻿namespace BookStore.Shared.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message, "NOT_FOUND")
        {
        }
    }
}