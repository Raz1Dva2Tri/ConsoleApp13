using System;
using System.Collections.Generic;
using ConsoleApp13.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp13;

public partial class PmpDbContext : DbContext
{
    public PmpDbContext()
    {
    }

    public PmpDbContext(DbContextOptions<PmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<АдминистраторыБд> АдминистраторыБдs { get; set; }

    public virtual DbSet<АдминистраторыБдМониторинг> АдминистраторыБдМониторингs { get; set; }

    public virtual DbSet<ВидыМеталлопродукции> ВидыМеталлопродукцииs { get; set; }

    public virtual DbSet<Города> Городаs { get; set; }

    public virtual DbSet<ЕдиницыИзмерения> ЕдиницыИзмеренияs { get; set; }

    public virtual DbSet<Металлопродукция> Металлопродукцияs { get; set; }

    public virtual DbSet<Покупатели> Покупателиs { get; set; }

    public virtual DbSet<Сделки> Сделкиs { get; set; }

    public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }

    public virtual DbSet<СтатусыСделки> СтатусыСделкиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=desktop-3r609fa\\server12;Database=PMP-DB;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<АдминистраторыБд>(entity =>
        {
            entity
                .ToTable("Администраторы_БД", tb => tb.HasTrigger("monitoring_trigger"));

            entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");
            entity.Property(e => e.Пароль).HasMaxLength(50);

            entity.HasOne(d => d.IdСотрудникаNavigation).WithMany()
                .HasForeignKey(d => d.IdСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Администраторы_БД_Сотрудники");
        });

        modelBuilder.Entity<АдминистраторыБдМониторинг>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Администраторы_БД_Мониторинг");

            entity.Property(e => e.ВремяМодификации)
                .HasColumnType("datetime")
                .HasColumnName("Время_модификации");
            entity.Property(e => e.Компьютер).HasMaxLength(50);
            entity.Property(e => e.НовоеЗначение)
                .HasMaxLength(250)
                .HasColumnName("Новое_значение");
            entity.Property(e => e.Операция)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Пользователь).HasMaxLength(50);
            entity.Property(e => e.ПрежнееЗначение)
                .HasMaxLength(250)
                .HasColumnName("Прежнее_значение");
        });

        modelBuilder.Entity<ВидыМеталлопродукции>(entity =>
        {
            entity.HasKey(e => e.IdВидаМеталлопродукции).HasName("PK__ВидыМета__B84103BC223341AF");

            entity.ToTable("ВидыМеталлопродукции");

            entity.Property(e => e.IdВидаМеталлопродукции).HasColumnName("ID_Вида_металлопродукции");
            entity.Property(e => e.НаименованиеВидаМеталлопродукции)
                .HasMaxLength(100)
                .HasColumnName("Наименование_вида_металлопродукции");
        });

        modelBuilder.Entity<Города>(entity =>
        {
            entity.HasKey(e => e.IdГорода);

            entity.ToTable("Города");

            entity.Property(e => e.IdГорода).HasColumnName("ID_Города");
            entity.Property(e => e.Город).HasMaxLength(50);
        });

        modelBuilder.Entity<ЕдиницыИзмерения>(entity =>
        {
            entity.HasKey(e => e.IdЕдиницыИзмерения);

            entity.ToTable("ЕдиницыИзмерения");

            entity.Property(e => e.IdЕдиницыИзмерения).HasColumnName("ID_Единицы_измерения");
            entity.Property(e => e.ЕдиницыИзмерения1)
                .HasMaxLength(50)
                .HasColumnName("Единицы_измерения");
        });

        modelBuilder.Entity<Металлопродукция>(entity =>
        {
            entity.HasKey(e => e.IdМеталлопродукции).HasName("PK__Металлоп__75562F65C0C916EE");

            entity.ToTable("Металлопродукция");

            entity.Property(e => e.IdМеталлопродукции).HasColumnName("ID_Металлопродукции");
            entity.Property(e => e.IdВидаМеталлопродукции).HasColumnName("ID_Вида_металлопродукции");
            entity.Property(e => e.НаименованиеМеталлопродукции)
                .HasMaxLength(100)
                .HasColumnName("Наименование_металлопродукции");

            entity.HasOne(d => d.IdВидаМеталлопродукцииNavigation).WithMany(p => p.Металлопродукцияs)
                .HasForeignKey(d => d.IdВидаМеталлопродукции)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Металлопродукция_ВидыМеталлопродукции");
        });

        modelBuilder.Entity<Покупатели>(entity =>
        {
            entity.HasKey(e => e.IdПокупателя);

            entity.ToTable("Покупатели");

            entity.Property(e => e.IdПокупателя).HasColumnName("ID_Покупателя");
            entity.Property(e => e.IdГорода).HasColumnName("ID_Города");
            entity.Property(e => e.АббревиатураПокупателя)
                .HasMaxLength(50)
                .HasColumnName("Аббревиатура_покупателя");
            entity.Property(e => e.АдресРегистрации)
                .HasMaxLength(150)
                .HasColumnName("Адрес_регистрации");
            entity.Property(e => e.НаименованиеПокупателя)
                .HasMaxLength(200)
                .HasColumnName("Наименование_покупателя");
            entity.Property(e => e.НомерТелефона)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Номер_телефона");

            entity.HasOne(d => d.IdГородаNavigation).WithMany(p => p.Покупателиs)
                .HasForeignKey(d => d.IdГорода)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Покупатели_Города");
        });

        modelBuilder.Entity<Сделки>(entity =>
        {
            entity.HasKey(e => new { e.IdПокупателя, e.IdМеталлопродукции, e.ДатаЗаказа });

            entity.ToTable("Сделки");

            entity.Property(e => e.IdПокупателя).HasColumnName("ID_Покупателя");
            entity.Property(e => e.IdМеталлопродукции).HasColumnName("ID_Металлопродукции");
            entity.Property(e => e.ДатаЗаказа)
                .HasColumnType("date")
                .HasColumnName("Дата_заказа");
            entity.Property(e => e.IdЕдиницыИзмерения).HasColumnName("ID_Единицы_измерения");
            entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");
            entity.Property(e => e.IdСтатусаСделки).HasColumnName("ID_Статуса_сделки");
            entity.Property(e => e.ДатаПоставкиПлан)
                .HasColumnType("date")
                .HasColumnName("Дата_поставки_план");
            entity.Property(e => e.ДатаПоставкиФакт)
                .HasColumnType("date")
                .HasColumnName("Дата_поставки_факт");
            entity.Property(e => e.КоличествоЕд).HasColumnName("Количество_ед");
            entity.Property(e => e.КоэффициентЦены).HasColumnName("Коэффициент_цены");
            entity.Property(e => e.ПродолжительностьПоставкиДниПлан).HasColumnName("Продолжительность_поставки_дни_план");
            entity.Property(e => e.ПродолжительностьПоставкиДниФакт).HasColumnName("Продолжительность_поставки_дни_факт");
            entity.Property(e => e.СтоимостьРуб).HasColumnName("Стоимость_руб");

            entity.HasOne(d => d.IdЕдиницыИзмеренияNavigation).WithMany(p => p.Сделкиs)
                .HasForeignKey(d => d.IdЕдиницыИзмерения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сделки_ЕдиницыИзмерения");

            entity.HasOne(d => d.IdМеталлопродукцииNavigation).WithMany(p => p.Сделкиs)
                .HasForeignKey(d => d.IdМеталлопродукции)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сделки_Металлопродукция");

            entity.HasOne(d => d.IdПокупателяNavigation).WithMany(p => p.Сделкиs)
                .HasForeignKey(d => d.IdПокупателя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сделки_Покупатели");

            entity.HasOne(d => d.IdСотрудникаNavigation).WithMany(p => p.Сделкиs)
                .HasForeignKey(d => d.IdСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сделки_Сотрудники");

            entity.HasOne(d => d.IdСтатусаСделкиNavigation).WithMany(p => p.Сделкиs)
                .HasForeignKey(d => d.IdСтатусаСделки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сделки_СтатусыСделки");
        });

        modelBuilder.Entity<Сотрудники>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника);

            entity.ToTable("Сотрудники");

            entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ВозрастЛет)
                .HasComputedColumnSql("(datepart(year,getdate())-datepart(year,[Дата_рождения]))", false)
                .HasColumnName("Возраст_лет");
            entity.Property(e => e.ДатаРождения)
                .HasColumnType("date")
                .HasColumnName("Дата_рождения");
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.НомерТелефона)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Номер_телефона");
            entity.Property(e => e.Отчество).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(50);
        });

        modelBuilder.Entity<СтатусыСделки>(entity =>
        {
            entity.HasKey(e => e.IdСтатусаСделки);

            entity.ToTable("СтатусыСделки");

            entity.Property(e => e.IdСтатусаСделки).HasColumnName("ID_Статуса_сделки");
            entity.Property(e => e.СтатусСделки)
                .HasMaxLength(50)
                .HasColumnName("Статус_сделки");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
