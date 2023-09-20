﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SS5Pos.Models;

public class Category
{
	[Key]
	public Guid CategoryId { get; set; }
	[Required,MaxLength(50)]
	[Display(Name ="Category Name")]
	public string? CategoryName { get; set; }
}

