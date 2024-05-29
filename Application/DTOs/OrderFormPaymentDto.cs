﻿namespace Application.DTOs
{
    public class OrderFormPaymentDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PayAmount { get; set; }
        public int PayTypeId { get; set; }
        public int PayById { get; set; }
    }
}