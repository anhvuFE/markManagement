namespace WebClient.DTO.StudentGrade
{
    public class StudentViewGradeDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public List<GradeTypeDTO> GradeTypes { get; set; }
    }

    public class GradeTypeDTO
    {
        public int GradeTypeId { get; set; }
        public string GradeTypeName { get; set; }
        public List<GradeDTO> Grades { get; set; }
    }

    public class GradeDTO
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int Weight { get; set; }
        public string Value { get; set; }
    }
}
