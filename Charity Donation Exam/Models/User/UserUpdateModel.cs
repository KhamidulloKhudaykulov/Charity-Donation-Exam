﻿namespace Charity_Donation_Exam.Models.User;

public class UserUpdateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DateTime UpdatedAt { get; set; }
}