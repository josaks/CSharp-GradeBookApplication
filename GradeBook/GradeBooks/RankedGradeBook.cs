﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks {
	public class RankedGradeBook : BaseGradeBook {
		public RankedGradeBook(string name) : base(name) {
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade) {
			if(base.Students.Count < 5) throw new InvalidOperationException("Less than 5 students");

			var threshold = (int)Math.Ceiling(Students.Count * 0.2);
			var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
			
			if(grades[threshold - 1] < averageGrade) {
				return 'A';
			}
			else if(grades[threshold*2 - 1] < averageGrade) {
				return 'B';
			}
			else if(grades[threshold*3 - 1 ] < averageGrade) {
				return 'C';
			}
			else if (grades[threshold * 3 - 1] < averageGrade) {
				return 'C';
			}
			return 'F';
		}
	}
}
