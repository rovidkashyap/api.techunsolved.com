using AutoMapper;
using api.techunsolved.com.Data;
using api.techunsolved.com.Models.Dto;
using api.techunsolved.com.Models.Dto.TechArticleDto;
using api.techunsolved.com.Models.Dto.TechArticlesDataDto;
using api.techunsolved.com.Models.Dto.TechModulesDto;
using api.techunsolved.com.Models.Dto.TechTopicDto;
using Microsoft.OpenApi.Services;

namespace api.techunsolved.com.Configurations.MapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TechCategory, TechCategoryDto>().ReverseMap();
            
            CreateMap<TechSubcategory, TechSubCategoryDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.Initial))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.TechCategoryId))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.TechCategory.TechCategoryName))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();

            CreateMap<TechSubcategory, CreateSubCategoryDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.Initial))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.TechCategoryId))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();

            CreateMap<TechSubcategory, UpdateSubCategoryDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.Initial))
                .ForMember(x => x.categoryId, opt => opt.MapFrom(x => x.TechCategoryId))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();

            CreateMap<TechSubcategory, GetSubCategoryByIdDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.Initial))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.TechCategory.TechCategoryName))
                .ReverseMap();

            CreateMap<TechSubcategory, GetSubCategoryByCategoryNameDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.Initial))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();

            //CreateMap<TechSubcategory, GetSubCategoryByCatIdDto>()
            //    .ForMember(x => x.TechCategoryId, opt => opt.MapFrom(x => x.TechCategoryId))
            //    .ForMember(x => x.TechCategoryName, opt => opt.MapFrom(x => x.TechCategory.TechCategoryName))
            //    .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreateDate))
            //    .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
            //    .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
            //    .ForMember(x => x.TechSubcategoryName, opt => opt.MapFrom(x => x.TechSubcategoryName))
            //    .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
            //    .ReverseMap();

            CreateMap<TechModules, GetAllTechModuleDto>()
                .ForMember(x => x.TechSubCategoryName, opt => opt.MapFrom(x => x.TechSubCategories.TechSubcategoryName))
                .ReverseMap();

            CreateMap<TechModules, CreateTechModuleDto>()
                .ForMember(x => x.TechSubcategoryId, opt => opt.MapFrom(x => x.TechSubcategoryId))
                .ReverseMap();

            CreateMap<TechModules, GetAllModulesBySubCategoryDto>().ReverseMap();

            CreateMap<TechModules, GetModulesByInitialDto>()
                .ForMember(x => x.TechSubCategoryId, opt => opt.MapFrom(x => x.TechSubCategories.TechCategoryId))
                .ForMember(x => x.TechSubCategoryName, opt => opt.MapFrom(x => x.TechSubCategories.TechSubcategoryName))
                .ReverseMap();

            CreateMap<TechTopics, GetAllTechTopicsDto>()
                .ForMember(x => x.TechModulesName, opt => opt.MapFrom(x => x.techModules.TechModulesName))
                .ReverseMap();

            CreateMap<TechTopics, GetAllTechTopicsWithInitialDto>()
                .ForMember(x => x.TechModulesName, opt => opt.MapFrom(x => x.techModules.TechModulesName))
                .ForMember(x => x.Initial, opt => opt.MapFrom(x => x.techModules.Initial))
                .ReverseMap();

            CreateMap<TechTopics, GetAllTopicsByLevelDto>()
                .ForMember(x => x.TechModulesName, opt => opt.MapFrom(x => x.techModules.TechModulesName))
                .ReverseMap();

            CreateMap<TechTopics, CreateTechTopicDto>().ReverseMap();

            CreateMap<TechArticles, GetAllArticlesWithTopicsDto>()
                .ForMember(x => x.techArticleId, opt => opt.MapFrom(x => x.TechArticleId))
                .ForMember(x => x.main_Heading, opt => opt.MapFrom(x => x.main_Heading))
                .ForMember(x => x.main_subHeading, opt => opt.MapFrom(x => x.main_subHeading))
                .ForMember(x => x.intro_Heading, opt => opt.MapFrom(x => x.intro_Heading))
                .ForMember(x => x.intro_Data, opt => opt.MapFrom(x => x.intro_Data))
                .ForMember(x => x.content_Heading, opt => opt.MapFrom(x => x.content_Heading))
                .ForMember(x => x.content_Data, opt => opt.MapFrom(x => x.content_Data))
                .ForMember(x => x.example_content, opt => opt.MapFrom(x => x.example_content))
                .ForMember(x => x.output_content, opt => opt.MapFrom(x => x.output_content))
                .ForMember(x => x.conclusion_data, opt => opt.MapFrom(x => x.conclusion_data))
                .ForMember(x => x.other_Content, opt => opt.MapFrom(x => x.other_Content))
                .ForMember(x => x.techTopicId, opt => opt.MapFrom(x => x.techTopicId))
                .ForMember(x => x.TechTopicName, opt => opt.MapFrom(x => x.techTopic.TechTopicName))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();

            CreateMap<TechArticles, GetAllArticlesDto>().ReverseMap();

            CreateMap<TechArticles, CreateArticleDto>().ReverseMap();

            CreateMap<TechArticlesData, CreateTechArticlesDataDto>()
                .ForMember(x => x.TechArticlesDataId, opt => opt.MapFrom(x => x.TechArticlesDataId))
                .ForMember(x => x.TechArticlesId, opt => opt.MapFrom(x => x.TechArticlesId))
                .ReverseMap();

            CreateMap<TechArticlesData, GetAllTechArticlesDataDto>()
                .ForMember(x => x.TechArticlesDataId, opt => opt.MapFrom(x => x.TechArticlesDataId))
                .ForMember(x => x.TechArticlesId, opt => opt.MapFrom(x => x.TechArticlesId))
                .ForMember(x => x.techArticlesNames, opt => opt.MapFrom(x => x.TechArticles.main_Heading))
                .ForMember(x => x.program_heading, opt => opt.MapFrom(x => x.program_heading))
                .ForMember(x => x.program_code, opt => opt.MapFrom(x => x.program_code))
                .ForMember(x => x.output_heading, opt => opt.MapFrom(x => x.output_heading))
                .ForMember(x => x.output_code, opt => opt.MapFrom(x => x.output_code))
                .ForMember(x => x.other_heading, opt => opt.MapFrom(x => x.other_heading))
                .ForMember(x => x.other_code, opt => opt.MapFrom(x => x.other_code))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreateDate))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(x => x.LastModifiedDate))
                .ReverseMap();
        }
    }
}
