using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    // Represents a stored credential with validation
    public class Credential
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Site name is required")]
        [StringLength(200, ErrorMessage = "Site name cannot exceed 200 characters")]
        public string Site { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Credential()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            Notes = string.Empty;
        }

        public Credential(string site, string username, string password, string notes = "") : this()
        {
            Site = site;
            Username = username;
            Password = password;
            Notes = notes;
        }

        // Updates the credential and sets the modified date
        public void Update(string site, string username, string password, string notes = "")
        {
            Site = site;
            Username = username;
            Password = password;
            Notes = notes;
            ModifiedDate = DateTime.UtcNow;
        }

        // Validates the credential data
        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Site))
            {
                errorMessage = "Site name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                errorMessage = "Username is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                errorMessage = "Password is required";
                return false;
            }

            if (Site.Length > 200)
            {
                errorMessage = "Site name cannot exceed 200 characters";
                return false;
            }

            if (Username.Length > 100)
            {
                errorMessage = "Username cannot exceed 100 characters";
                return false;
            }

            if (!string.IsNullOrEmpty(Notes) && Notes.Length > 500)
            {
                errorMessage = "Notes cannot exceed 500 characters";
                return false;
            }

            return true;
        }

        // Returns a safe string representation (without password)
        public override string ToString()
        {
            return $"Site: {Site}, Username: {Username}, Created: {CreatedDate:yyyy-MM-dd}";
        }

        // Returns a detailed string representation (without password)
        public string ToDetailedString()
        {
            return $"""
                ID: {Id}
                Site: {Site}
                Username: {Username}
                Notes: {(string.IsNullOrEmpty(Notes) ? "(none)" : Notes)}
                Created: {CreatedDate:yyyy-MM-dd HH:mm:ss} UTC
                Modified: {ModifiedDate:yyyy-MM-dd HH:mm:ss} UTC
                """;
        }
    }
}