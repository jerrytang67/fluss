﻿// <auto-generated />
using System;
using Cnblogs.Fluss.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cnblogs.Fluss.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20210328100829_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.BlogPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AutoDesc")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsExist")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BlogId", "IsExist", "IsPublished", "DateCreated");

                    b.ToTable("blog_post");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.BlogSite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("HomePageSize")
                        .HasColumnType("int");

                    b.Property<bool>("IsExist")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("blog_site");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsExist")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<string>("Raw")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("PostId");

                    b.ToTable("blog_content_block");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.ContentRenderConfig", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BlogPostId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ContentBlockId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsExist")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("RendererData")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RendererId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("ContentBlockId");

                    b.ToTable("blog_content_render_config");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.BlogPost", b =>
                {
                    b.HasOne("Cnblogs.Fluss.Domain.Entities.BlogSite", "BlogSite")
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BlogSite");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.ContentBlock", b =>
                {
                    b.HasOne("Cnblogs.Fluss.Domain.Entities.BlogSite", "BlogSite")
                        .WithMany("ContentBlocks")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cnblogs.Fluss.Domain.Entities.BlogPost", "BlogPost")
                        .WithMany("ContentBlocks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BlogPost");

                    b.Navigation("BlogSite");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.ContentRenderConfig", b =>
                {
                    b.HasOne("Cnblogs.Fluss.Domain.Entities.BlogPost", null)
                        .WithMany("ContentRenderConfigs")
                        .HasForeignKey("BlogPostId");

                    b.HasOne("Cnblogs.Fluss.Domain.Entities.ContentBlock", null)
                        .WithMany("RenderConfigs")
                        .HasForeignKey("ContentBlockId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.BlogPost", b =>
                {
                    b.Navigation("ContentBlocks");

                    b.Navigation("ContentRenderConfigs");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.BlogSite", b =>
                {
                    b.Navigation("BlogPosts");

                    b.Navigation("ContentBlocks");
                });

            modelBuilder.Entity("Cnblogs.Fluss.Domain.Entities.ContentBlock", b =>
                {
                    b.Navigation("RenderConfigs");
                });
#pragma warning restore 612, 618
        }
    }
}