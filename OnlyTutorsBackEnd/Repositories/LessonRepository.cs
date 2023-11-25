﻿using Dapper;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;
using System.Data;

namespace OnlyTutorsBackEnd.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private DapperContext _context;

        public LessonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetLessons()
        {
            try
            {
                string query = "SELECT * FROM Lessons";

                using (var connection = _context.CreateConnection())
                {
                    var lessons = await connection.QueryAsync<Lesson>(query);
                    return lessons.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return Enumerable.Empty<Lesson>();
            }
        }

        public async Task<IEnumerable<Student>> GetAllLessonStudents(int lessonid)
        {
            try
            {
                string query = "SELECT U.* FROM Users U JOIN Students S ON U.Id = S.userId JOIN StudentLessons SL ON S.userId = SL.StudentId JOIN Lessons L ON SL.LessonId = L.Id WHERE L.Id = @lessonid; ";

                var parameters = new DynamicParameters();
                parameters.Add("lessonid", lessonid, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    var students = await connection.QueryAsync<Student>(query, parameters);
                    return students.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return Enumerable.Empty<Student>();
            }
        }

        public async Task<int> InsertLesson(Lesson lesson)
        {
            try
            {
                string query = "INSERT INTO Lessons (name,subjectid, description, time, tutorid) VALUES (@name, @subjectid, @description, @time, @tutorid)";

                var parameters = new DynamicParameters();
                parameters.Add("name", lesson.Name, DbType.String);
                parameters.Add("subjectid", lesson.SubjectId, DbType.Int32);
                parameters.Add("description", lesson.Description, DbType.String);
                parameters.Add("time", lesson.Time, DbType.DateTime);
                parameters.Add("@tutorid", lesson.tutorid, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    if (await connection.ExecuteAsync(query, parameters) > 0)
                        return 1;
                    else
                        return -1;
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return -1;
            }
        }

        public async Task<int> InsertStudentLessons(int studentid, int lessonid)
        {
            try
            {
                string query = "INSERT INTO StudentLessons (studentid, lessonid) VALUES (@studentid, @lessonid)";

                var parameters = new DynamicParameters();
                parameters.Add("studentid", studentid, DbType.Int32);
                parameters.Add("lessonid", lessonid, DbType.Int32);

                using (var connection = _context.CreateConnection())
                {
                    if (await connection.ExecuteAsync(query, parameters) > 0)
                        return 1;
                    else
                        return -1;
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return -1;
            }
        }

        public async Task<IEnumerable<Lesson>> SearchForLessons(string searchString)
        {
            try
            {
                string query = "SELECT * FROM GetLessonByName(@search) UNION SELECT * FROM GetLessonByTutor(@search) UNION SELECT * FROM GetLessonBySubject(@search)";


                var parameters = new DynamicParameters();
                parameters.Add("search", searchString, DbType.String);

                using (var connection = _context.CreateConnection())
                {
                    var lessons = await connection.QueryAsync<Lesson>(query,parameters);
                    return lessons.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return Enumerable.Empty<Lesson>();
            }
        }
    }
}
