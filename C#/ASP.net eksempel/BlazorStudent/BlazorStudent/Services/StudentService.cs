using BlazorStudent.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace BlazorStudent.Services
{
    public class StudentService
    {
        //private readonly StudDbContext _context;

        private readonly HttpClient _httpClient;
        /*
        public StudentService(StudDbContext context)
        {
            this._context = context;
        }
        */
        public StudentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<Student>> GetStudents()
        {
            List<Student> students = new List<Student>();
            students = await _httpClient.GetFromJsonAsync<List<Student>>("/api/Students");
            //students = await _context.Students.ToListAsync();
            return students;
        }
        
        public async Task<List<Student>> SearchStudent(string studName)
        {
            List<Student> students = new List<Student>();
            students = await GetStudents();
            students = students.Where(s => s.Studentname.Contains(studName)).ToList();
            //students = await _context.Students.Where(s=>s.Studentname.Contains(studName)).ToListAsync();
            return students;
        }
        
        public async Task<Student> GetStudent(int id)
        {
            Student student = await _httpClient.GetFromJsonAsync<Student>("/api/Students/" + id);
            return student;
            //return await _context.Students.FindAsync(id);
        }
        

        public async Task UpdateStudent(Student student)
        {
            await _httpClient.PutAsJsonAsync<Student>("api/Students/"+student.Id,student);
             //_context.Students.Update(student);
            //await _context.SaveChangesAsync();
            
        }
        
    }
}
