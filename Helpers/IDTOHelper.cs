﻿using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Topics;
using Nop.Plugin.Api.DTO.Categories;
using Nop.Plugin.Api.DTO.Languages;
using Nop.Plugin.Api.DTO.Manufacturers;
using Nop.Plugin.Api.DTO.OrderItems;
using Nop.Plugin.Api.DTO.Orders;
using Nop.Plugin.Api.DTO.ProductAttributes;
using Nop.Plugin.Api.DTO.Products;
using Nop.Plugin.Api.DTO.ShoppingCarts;
using Nop.Plugin.Api.DTO.SpecificationAttributes;
using Nop.Plugin.Api.DTO.Stores;
using Nop.Plugin.Api.DTO.Topics;

namespace Nop.Plugin.Api.Helpers
{
    public interface IDTOHelper
    {
        ProvinceDTO PrepareProvinceDTO(StateProvince province);
        ProductDto PrepareProductDTO(Product product);
        CategoryDto PrepareCategoryDTO(Category category);
        TopicDto PrepareTopicToDTO(Topic topic);
        OrderDto PrepareOrderDTO(Order order);
        ShoppingCartItemDto PrepareShoppingCartItemDTO(ShoppingCartItem shoppingCartItem);
        OrderItemDto PrepareOrderItemDTO(OrderItem orderItem);
        StoreDto PrepareStoreDTO(Store store);
        LanguageDto PrepareLanguageDto(Language language);
        ProductAttributeDto PrepareProductAttributeDTO(ProductAttribute productAttribute);
        ProductSpecificationAttributeDto PrepareProductSpecificationAttributeDto(ProductSpecificationAttribute productSpecificationAttribute);
        SpecificationAttributeDto PrepareSpecificationAttributeDto(SpecificationAttribute specificationAttribute);
        ManufacturerDto PrepareManufacturerDto(Manufacturer manufacturer);
    }
}
