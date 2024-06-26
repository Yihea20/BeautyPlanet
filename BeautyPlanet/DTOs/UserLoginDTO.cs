﻿using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class UserRegistDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Point { get; set; }
        public string DeviceTokken { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? ImageURL { get; set; }
        public string? ProfileImageURL { get; set; }
        public ICollection<string> RoleName { get; set; }
       // public int CenterId { get; set; }

    }
    public class location{
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class photo
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
        
    }
    public class UserLoginDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
    }
    public class GetUserDTO:UserRegistDTO
    {
        public string Id { get; set; }
        
        
    }
    public class GetUserHome
    {
        public int Point { get; set; }
    }
    public class SpecialisRegistDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Specialization { get; set; }
        public int CenterId { get; set; }
        public int Rate { get; set; }
        public string Exparences { get; set; }
        public string DeviceTokken { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? ImageURL { get; set; }
        public string? ProfileImageURL { get; set; }
        public ICollection<string> RoleName { get; set; }
        // public int CenterId { get; set; }

    }
    public class GetSpecialistDTO
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CenterId { get; set; }
        public int Rate { get; set; }
        public string Exparences { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public IList<DateTime>? Times { get; set; }
    }
    public class AppSpecialist
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
    public class UserReviews
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
    }
}
