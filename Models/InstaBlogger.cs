using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace a.Models
{
    public class InstaBlogger
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Instagram { get; set; }
        public string Age { get; set; }
    

  public BaseModelValidationResult Validate()
       {
           var validationResult = new BaseModelValidationResult();

           if (string.IsNullOrWhiteSpace(Name)) validationResult.Append($"Имя не может иметь пустое значение");
           if (string.IsNullOrWhiteSpace(Surname)) validationResult.Append($"Фамилия не может иметь пустое значение");
           if (!string.IsNullOrEmpty(Name) && !char.IsUpper(Name.FirstOrDefault())) validationResult.Append($"Name {Name} should start from capital letter");
           if (!string.IsNullOrEmpty(Surname) && !char.IsUpper(Surname.FirstOrDefault())) validationResult.Append($"Surname {Surname} should start from capital letter");

           return validationResult;
       }

       public override string ToString()
       {
           return $"{Name} {Surname} from {Age}@{Instagram}";
       }
   }
}
