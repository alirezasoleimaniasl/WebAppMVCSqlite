using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppMVCSqlite.Areas.Admin.Models.ViewModels
{
    public class PatientCreateEditViewModel
    {
        public PatientCreateEditViewModel() { }
        //Patient
        public long PatientId { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "نام ")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "نام خانوادگی ")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "کد ملی ")]
        public string? NationalCode { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "تاریخ تولد ")]
        public string? DateOfBirth { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "جنسیت ")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "شغل ")]
        public string? Job { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "نام پدر ")]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "وضعیت بیمار ")]
        public long? PatientStatusId { get; set; }
        //Hospital
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "بیمارستان پذیرش ")]
        //labratory
        public long HospitalId { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "آزمایشگاه")]
        public short LabId { get; set; }

        [Display(Name = "نوبت های واکسن")]
        public short? firstVaccineId { get; set; }

        [Display(Name = "نوع واکسن دوم ")]
        public short? secondVaccineId { get; set; }
        [Display(Name = "نوع واکسن سوم ")]
        public short? thirdVaccineId { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "شهرستان محل سکونت ")]
        public short? CityId { get; set; }
        [Required(ErrorMessage = "وارد نمودن {0} الزامی است.")]
        [Display(Name = "آدرس کامل محل سکونت")]
        public string? FullAddress { get; set; }
        [Display(Name = "شماره همراه")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "تاریخ نمونه گیری")]
        public string? SamplingDate { get; set; }
        [Display(Name = "تاریخ ارسال نمونه به آزمایشگاه")]
        public string? ToLabDate { get; set; }
        [Display(Name = "تاریخ جواب آزمایش")]
        public string? AnswerDate { get; set; }
        [Display(Name = "نتیجه آزمایش")]
        public bool TestAnswer { get; set; }

    }
}
