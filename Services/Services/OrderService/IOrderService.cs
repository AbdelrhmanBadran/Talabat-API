﻿using Core.Entities;
using Services.Services.OrderService.Dto;

namespace Services.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderResultDto> CreateOrderAsync(OrderDto orderDto);
        Task<IReadOnlyList<OrderResultDto>> GetAllOrdersForUsersAsync(string buyerEmail);
        Task<OrderResultDto> GetOrderByIdAsync(int id,string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync();
    }
}
