using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class BohovaContext : DbContext
{
    public BohovaContext()
    {
    }

    public BohovaContext(DbContextOptions<BohovaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DboBisDobaviteljiUnp> DboBisDobaviteljiUnps { get; set; }

    public virtual DbSet<DboBisVozilaUnp> DboBisVozilaUnps { get; set; }

    public virtual DbSet<DboBisVoznikiUnp> DboBisVoznikiUnps { get; set; }

    public virtual DbSet<DboDrzave> DboDrzaves { get; set; }

    public virtual DbSet<DboPoslovniPartnerji> DboPoslovniPartnerjis { get; set; }

    public virtual DbSet<DboPostum> DboPosta { get; set; }

    public virtual DbSet<DboUnpSklIzdaje> DboUnpSklIzdajes { get; set; }

    public virtual DbSet<DboUnpSklPrevzemi> DboUnpSklPrevzemis { get; set; }

    public virtual DbSet<DboUporabniki> DboUporabnikis { get; set; }

    public virtual DbSet<Dobavitelji> Dobaviteljis { get; set; }

    public virtual DbSet<Izdaje> Izdajes { get; set; }

    public virtual DbSet<Lastniki> Lastnikis { get; set; }

    public virtual DbSet<MasaRezervoarji> MasaRezervoarjis { get; set; }

    public virtual DbSet<PasteError> PasteErrors { get; set; }

    public virtual DbSet<PrevoznoSredstvo> PrevoznoSredstvos { get; set; }

    public virtual DbSet<Prevzemi> Prevzemis { get; set; }

    public virtual DbSet<ScadaUporabniki> ScadaUporabnikis { get; set; }

    public virtual DbSet<TocilnePoti> TocilnePotis { get; set; }

    public virtual DbSet<TrosarinskaSkladisca> TrosarinskaSkladiscas { get; set; }

    public virtual DbSet<Uporabniki> Uporabnikis { get; set; }

    public virtual DbSet<Vozila> Vozilas { get; set; }

    public virtual DbSet<Vozniki> Voznikis { get; set; }

    public virtual DbSet<VrstePlina> VrstePlinas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=Bohova;Trusted_Connection=False;TrustServerCertificate=True;User Id=sa;Password=Welcome!1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC07F1058082");

            entity.Property(e => e.Ip).HasMaxLength(45);
        });

        modelBuilder.Entity<DboBisDobaviteljiUnp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_bis_dobavitelji_unp");

            entity.Property(e => e.DavcnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("davcna_stevilka");
            entity.Property(e => e.Dodatek)
                .HasMaxLength(6)
                .HasColumnName("dodatek");
            entity.Property(e => e.Drzava).HasColumnName("drzava");
            entity.Property(e => e.HisnaStevilka)
                .HasMaxLength(6)
                .HasColumnName("hisna_stevilka");
            entity.Property(e => e.Kraj)
                .HasMaxLength(25)
                .HasColumnName("kraj");
            entity.Property(e => e.KrajPp)
                .HasMaxLength(50)
                .HasColumnName("kraj_pp");
            entity.Property(e => e.NaslovPp)
                .HasMaxLength(50)
                .HasColumnName("naslov_pp");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("naziv");
            entity.Property(e => e.NazivPp)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp");
            entity.Property(e => e.NazivPpDod)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp_dod");
            entity.Property(e => e.PoslovniPartner).HasColumnName("poslovni_partner");
            entity.Property(e => e.PostnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("postna_stevilka");
            entity.Property(e => e.StatusDdv)
                .HasMaxLength(1)
                .HasColumnName("status_ddv");
        });

        modelBuilder.Entity<DboBisVozilaUnp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_bis_vozila_unp");

            entity.Property(e => e.Dostopnost).HasColumnName("dostopnost");
            entity.Property(e => e.KonecVozenj)
                .HasPrecision(0)
                .HasColumnName("KONEC_VOZENJ");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.RegistrskaOznaka)
                .HasMaxLength(10)
                .HasColumnName("registrska_oznaka");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.Vozilo).HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.ZacetekVozenj)
                .HasPrecision(0)
                .HasColumnName("ZACETEK_VOZENJ");
        });

        modelBuilder.Entity<DboBisVoznikiUnp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_bis_vozniki_unp");

            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
        });

        modelBuilder.Entity<DboDrzave>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_DRZAVE");

            entity.Property(e => e.Drzava).HasColumnName("DRZAVA");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("NAZIV");
            entity.Property(e => e.SimbolA2)
                .HasMaxLength(2)
                .HasColumnName("SIMBOL_A2");
            entity.Property(e => e.SimbolA3)
                .HasMaxLength(3)
                .HasColumnName("SIMBOL_A3");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("SPR_DATETIME");
            entity.Property(e => e.SprUporabnik).HasColumnName("SPR_UPORABNIK");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("VPIS_DATETIME");
            entity.Property(e => e.VpisUporabnik).HasColumnName("VPIS_UPORABNIK");
        });

        modelBuilder.Entity<DboPoslovniPartnerji>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_POSLOVNI_PARTNERJI");

            entity.Property(e => e.DavcnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("davcna_stevilka");
            entity.Property(e => e.DdvKodaDrzave)
                .HasMaxLength(2)
                .HasColumnName("ddv_koda_drzave");
            entity.Property(e => e.DdvStevilka)
                .HasMaxLength(15)
                .HasColumnName("ddv_stevilka");
            entity.Property(e => e.DimKos).HasColumnName("DIM_KOS");
            entity.Property(e => e.DimSez)
                .HasMaxLength(10)
                .HasColumnName("DIM_SEZ");
            entity.Property(e => e.Dodatek)
                .HasMaxLength(6)
                .HasColumnName("DODATEK");
            entity.Property(e => e.Drzava).HasColumnName("DRZAVA");
            entity.Property(e => e.HisStevilka)
                .HasMaxLength(6)
                .HasColumnName("his_stevilka");
            entity.Property(e => e.HisnaStevilka)
                .HasMaxLength(12)
                .HasColumnName("HISNA_STEVILKA");
            entity.Property(e => e.IdObcine).HasColumnName("ID_OBCINE");
            entity.Property(e => e.IdRpe).HasColumnName("ID_RPE");
            entity.Property(e => e.Kategorija).HasColumnName("kategorija");
            entity.Property(e => e.KrajPp)
                .HasMaxLength(50)
                .HasColumnName("KRAJ_PP");
            entity.Property(e => e.NaslovPp)
                .HasMaxLength(50)
                .HasColumnName("NASLOV_PP");
            entity.Property(e => e.NazivPp)
                .HasMaxLength(50)
                .HasColumnName("NAZIV_PP");
            entity.Property(e => e.NazivPpDod)
                .HasMaxLength(50)
                .HasColumnName("NAZIV_PP_DOD");
            entity.Property(e => e.Oznaka)
                .HasMaxLength(15)
                .HasColumnName("OZNAKA");
            entity.Property(e => e.PoslovniPartner).HasColumnName("POSLOVNI_PARTNER");
            entity.Property(e => e.PostnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("POSTNA_STEVILKA");
            entity.Property(e => e.SifraNaselja)
                .HasMaxLength(6)
                .HasColumnName("SIFRA_NASELJA");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("SPR_DATETIME");
            entity.Property(e => e.SprUporabnik).HasColumnName("SPR_UPORABNIK");
            entity.Property(e => e.Stanovanje)
                .HasMaxLength(6)
                .HasColumnName("STANOVANJE");
            entity.Property(e => e.StatusDdv)
                .HasMaxLength(1)
                .HasColumnName("STATUS_DDV");
            entity.Property(e => e.StatusPp)
                .HasMaxLength(1)
                .HasColumnName("STATUS_PP");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("VPIS_DATETIME");
            entity.Property(e => e.VpisUporabnik).HasColumnName("VPIS_UPORABNIK");
            entity.Property(e => e.VrstaOsebe)
                .HasMaxLength(2)
                .HasColumnName("VRSTA_OSEBE");
        });

        modelBuilder.Entity<DboPostum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_POSTA");

            entity.Property(e => e.Kraj)
                .HasMaxLength(25)
                .HasColumnName("KRAJ");
            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .HasColumnName("NAZIV");
            entity.Property(e => e.Opis)
                .HasMaxLength(100)
                .HasColumnName("opis");
            entity.Property(e => e.PostnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("POSTNA_STEVILKA");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("SPR_DATETIME");
            entity.Property(e => e.SprUporabnik).HasColumnName("SPR_UPORABNIK");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("VPIS_DATETIME");
            entity.Property(e => e.VpisUporabnik).HasColumnName("VPIS_UPORABNIK");
        });

        modelBuilder.Entity<DboUnpSklIzdaje>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_unp_skl_izdaje");

            entity.Property(e => e.DatumOdpreme)
                .HasPrecision(0)
                .HasColumnName("datum_odpreme");
            entity.Property(e => e.DatumOdpremeKonec)
                .HasPrecision(0)
                .HasColumnName("datum_odpreme_konec");
            entity.Property(e => e.DejanskaKolicina).HasColumnName("dejanska_kolicina");
            entity.Property(e => e.DokumentDobavnice).HasColumnName("dokument_dobavnice");
            entity.Property(e => e.Lastnik).HasColumnName("lastnik");
            entity.Property(e => e.NacinOdpreme)
                .HasMaxLength(30)
                .HasColumnName("nacin_odpreme");
            entity.Property(e => e.OdpremniNalog).HasColumnName("odpremni_nalog");
            entity.Property(e => e.Operater)
                .HasMaxLength(30)
                .HasColumnName("operater");
            entity.Property(e => e.PredvidenaKolicina).HasColumnName("predvidena_kolicina");
            entity.Property(e => e.Relacija)
                .HasMaxLength(50)
                .HasColumnName("relacija");
            entity.Property(e => e.Skladisce).HasColumnName("skladisce");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TipPrevoznegaSredstva).HasColumnName("tip_prevoznega_sredstva");
            entity.Property(e => e.TocilniNalog).HasColumnName("tocilni_nalog");
            entity.Property(e => e.Veljavnost).HasColumnName("veljavnost");
            entity.Property(e => e.Vozilo).HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.VrstaPlina).HasColumnName("vrsta_plina");
        });

        modelBuilder.Entity<DboUnpSklPrevzemi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_unp_skl_prevzemi");

            entity.Property(e => e.DatumPrevzema)
                .HasPrecision(0)
                .HasColumnName("datum_prevzema");
            entity.Property(e => e.DatumPrevzemaKonec)
                .HasPrecision(0)
                .HasColumnName("datum_prevzema_konec");
            entity.Property(e => e.DejanskaKolicina).HasColumnName("dejanska_kolicina");
            entity.Property(e => e.Dobavitelj).HasColumnName("dobavitelj");
            entity.Property(e => e.DokumentDobavitelja)
                .HasMaxLength(30)
                .HasColumnName("dokument_dobavitelja");
            entity.Property(e => e.KolicinaPoDokumentih).HasColumnName("kolicina_po_dokumentih");
            entity.Property(e => e.Lastnik).HasColumnName("lastnik");
            entity.Property(e => e.NacinPrevzema)
                .HasMaxLength(30)
                .HasColumnName("nacin_prevzema");
            entity.Property(e => e.Operater)
                .HasMaxLength(30)
                .HasColumnName("operater");
            entity.Property(e => e.PrevzemniNalog).HasColumnName("prevzemni_nalog");
            entity.Property(e => e.Skladisce).HasColumnName("skladisce");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TipPrevoznegaSredstva).HasColumnName("tip_prevoznega_sredstva");
            entity.Property(e => e.Veljavnost).HasColumnName("veljavnost");
            entity.Property(e => e.Vozilo).HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.VrstaPlina).HasColumnName("vrsta_plina");
        });

        modelBuilder.Entity<DboUporabniki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo_uporabniki");

            entity.Property(e => e.Delavec).HasColumnName("delavec");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.ImeInPriimek)
                .HasMaxLength(25)
                .HasColumnName("ime_in_priimek");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
            entity.Property(e => e.Uporabnik).HasColumnName("uporabnik");
            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .HasColumnName("userid");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
        });

        modelBuilder.Entity<Dobavitelji>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dobavitelji");

            entity.Property(e => e.DavcnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("davcna_stevilka");
            entity.Property(e => e.Dodatek)
                .HasMaxLength(6)
                .HasColumnName("dodatek");
            entity.Property(e => e.Drzava).HasColumnName("drzava");
            entity.Property(e => e.HisnaStevilka)
                .HasMaxLength(6)
                .HasColumnName("hisna_stevilka");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Kraj)
                .HasMaxLength(25)
                .HasColumnName("kraj");
            entity.Property(e => e.KrajPp)
                .HasMaxLength(50)
                .HasColumnName("kraj_pp");
            entity.Property(e => e.NaslovPp)
                .HasMaxLength(50)
                .HasColumnName("naslov_pp");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("naziv");
            entity.Property(e => e.NazivPp)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp");
            entity.Property(e => e.NazivPpDod)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp_dod");
            entity.Property(e => e.PoslovniPartner).HasColumnName("poslovni_partner");
            entity.Property(e => e.PostnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("postna_stevilka");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.StatusDdv)
                .HasMaxLength(1)
                .HasColumnName("status_ddv");
        });

        modelBuilder.Entity<Izdaje>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .ToTable("Izdaje");

            entity.HasOne(i=>i.Vozila).WithMany().HasForeignKey(i=>i.Vozilo);
            entity.HasOne(i => i.Vozniki).WithMany().HasForeignKey(i => i.Voznik);

            entity.Property(e => e.DatumOdpreme)
                .HasPrecision(0)
                .HasColumnName("datum_odpreme");
            entity.Property(e => e.DatumOdpremeKonec)
                .HasPrecision(0)
                .HasColumnName("datum_odpreme_konec");
            entity.Property(e => e.DejanskaKolicina).HasColumnName("dejanska_kolicina");
            entity.Property(e => e.DokumentDobavnice).HasColumnName("dokument_dobavnice");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("ID tabele")
                .HasColumnName("ID");
            entity.Property(e => e.IdPis)
                .HasComment("ID od poslovnega sistema")
                .HasColumnName("ID_PIS");
            entity.Property(e => e.Lastnik).HasColumnName("lastnik");
            entity.Property(e => e.MmKonec)
                .HasDefaultValue(0)
                .HasColumnName("mm_konec");
            entity.Property(e => e.MmKonstanta)
                .HasDefaultValue(0f)
                .HasColumnName("mm_konstanta");
            entity.Property(e => e.MmRazlika)
                .HasDefaultValue(0)
                .HasColumnName("mm_razlika");
            entity.Property(e => e.MmSn)
                .HasMaxLength(50)
                .HasColumnName("mm_sn");
            entity.Property(e => e.MmStevilka)
                .HasDefaultValue((byte)0)
                .HasColumnName("mm_stevilka");
            entity.Property(e => e.MmTemp)
                .HasDefaultValue(0f)
                .HasColumnName("mm_temp");
            entity.Property(e => e.MmZacetek)
                .HasDefaultValue(0)
                .HasColumnName("mm_zacetek");
            entity.Property(e => e.NacinOdpreme)
                .HasMaxLength(30)
                .HasColumnName("nacin_odpreme");
            entity.Property(e => e.OdpremniNalog).HasColumnName("odpremni_nalog");
            entity.Property(e => e.Operater)
                .HasMaxLength(30)
                .HasColumnName("operater");
            entity.Property(e => e.PredvidenaKolicina).HasColumnName("predvidena_kolicina");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.RazlogPrekinitve)
                .HasMaxLength(200)
                .HasColumnName("razlog_prekinitve");
            entity.Property(e => e.Relacija)
                .HasMaxLength(50)
                .HasColumnName("relacija");
            entity.Property(e => e.ScadaVnos)
                .HasDefaultValue(false)
                .HasComment("Default na TRUE. Ko vnese nekdo novi RS cez SCADO se ta avtomatsko postavi na TRUE. Ko se RS prenese v PIS se postavi na FALSE.")
                .HasColumnName("SCADA_vnos");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.Skladisce)
                .HasDefaultValue(0)
                .HasColumnName("skladisce");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Status)
                .HasComment("1=odprt, 2=začetek, 3=točenje, 4=zaključevanje, 5=obdelan, 6=prekinjen")
                .HasColumnName("status");
            entity.Property(e => e.TipPrevoznegaSredstva).HasColumnName("tip_prevoznega_sredstva");
            entity.Property(e => e.TocilnaPot)
                .HasDefaultValue((byte)0)
                .HasColumnName("Tocilna_pot");
            entity.Property(e => e.TocilniNalog)
                .HasComment("Številka izdajnega naloga")
                .HasColumnName("tocilni_nalog");
            entity.Property(e => e.TocilnoMesto).HasColumnName("Tocilno_mesto");
            entity.Property(e => e.Veljavnost).HasColumnName("veljavnost");
            entity.Property(e => e.Vozilo).HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.VrstaCisterne)
                .HasDefaultValue((byte)0)
                .HasComment("0=mala, 1=velika")
                .HasColumnName("vrsta_cisterne");
            entity.Property(e => e.VrstaPlina).HasColumnName("vrsta_plina");
        });

        modelBuilder.Entity<Lastniki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Lastniki");

            entity.Property(e => e.DavcnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("davcna_stevilka");
            entity.Property(e => e.Dodatek)
                .HasMaxLength(6)
                .HasColumnName("dodatek");
            entity.Property(e => e.Drzava).HasColumnName("drzava");
            entity.Property(e => e.HisnaStevilka)
                .HasMaxLength(6)
                .HasColumnName("hisna_stevilka");
            entity.Property(e => e.Id)
                .HasDefaultValue(0)
                .HasColumnName("ID");
            entity.Property(e => e.Kraj)
                .HasMaxLength(25)
                .HasColumnName("kraj");
            entity.Property(e => e.KrajPp)
                .HasMaxLength(50)
                .HasColumnName("kraj_pp");
            entity.Property(e => e.NaslovPp)
                .HasMaxLength(50)
                .HasColumnName("naslov_pp");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("naziv");
            entity.Property(e => e.NazivPp)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp");
            entity.Property(e => e.NazivPpDod)
                .HasMaxLength(50)
                .HasColumnName("naziv_pp_dod");
            entity.Property(e => e.PoslovniPartner).HasColumnName("poslovni_partner");
            entity.Property(e => e.PostnaStevilka)
                .HasMaxLength(10)
                .HasColumnName("postna_stevilka");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.StatusDdv)
                .HasMaxLength(1)
                .HasColumnName("status_ddv");
        });

        modelBuilder.Entity<MasaRezervoarji>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Masa_Rezervoarji");

            entity.Property(e => e.Datum).HasPrecision(0);
            entity.Property(e => e.MasaRezervoar1)
                .HasDefaultValue(0.0)
                .HasColumnName("Masa_Rezervoar_1");
            entity.Property(e => e.MasaRezervoar2)
                .HasDefaultValue(0.0)
                .HasColumnName("Masa_Rezervoar_2");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<PasteError>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Paste Errors");

            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<PrevoznoSredstvo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Prevozno_sredstvo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<Prevzemi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Prevzemi");

            entity.Property(e => e.CelotnaCisterna)
                .HasDefaultValue(false)
                .HasColumnName("celotna_cisterna");
            entity.Property(e => e.DatumPrevzema)
                .HasPrecision(0)
                .HasColumnName("datum_prevzema");
            entity.Property(e => e.DatumPrevzemaKonec)
                .HasPrecision(0)
                .HasColumnName("datum_prevzema_konec");
            entity.Property(e => e.DejanskaKolicina).HasColumnName("dejanska_kolicina");
            entity.Property(e => e.Dobavitelj).HasColumnName("dobavitelj");
            entity.Property(e => e.DokumentDobavitelja)
                .HasMaxLength(30)
                .HasColumnName("dokument_dobavitelja");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("ID tabele")
                .HasColumnName("ID");
            entity.Property(e => e.IdPis)
                .HasComment("ID od poslovnega sistema")
                .HasColumnName("ID_PIS");
            entity.Property(e => e.KolicinaPoDokumentih)
                .HasDefaultValue(0.0)
                .HasColumnName("kolicina_po_dokumentih");
            entity.Property(e => e.Lastnik).HasColumnName("lastnik");
            entity.Property(e => e.MejaVsebnostC2c4)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_c2c4");
            entity.Property(e => e.MejaVsebnostC3)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_c3");
            entity.Property(e => e.MejaVsebnostDieni)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_dieni");
            entity.Property(e => e.MejaVsebnostOlje)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_olje");
            entity.Property(e => e.MejaVsebnostPp)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_pp");
            entity.Property(e => e.MejaVsebnostZveplo)
                .HasDefaultValue(0f)
                .HasColumnName("meja_vsebnost_zveplo");
            entity.Property(e => e.MmKonec)
                .HasDefaultValue(0)
                .HasColumnName("mm_konec");
            entity.Property(e => e.MmKonstanta)
                .HasDefaultValue(0f)
                .HasColumnName("mm_konstanta");
            entity.Property(e => e.MmRazlika)
                .HasDefaultValue(0)
                .HasColumnName("mm_razlika");
            entity.Property(e => e.MmSn)
                .HasMaxLength(50)
                .HasColumnName("mm_sn");
            entity.Property(e => e.MmStevilka)
                .HasDefaultValue((byte)0)
                .HasColumnName("mm_stevilka");
            entity.Property(e => e.MmTemp)
                .HasDefaultValue(0f)
                .HasColumnName("mm_temp");
            entity.Property(e => e.MmZacetek)
                .HasDefaultValue(0)
                .HasColumnName("mm_zacetek");
            entity.Property(e => e.NacinPrevzema)
                .HasMaxLength(30)
                .HasColumnName("nacin_prevzema");
            entity.Property(e => e.Operater)
                .HasMaxLength(30)
                .HasColumnName("operater");
            entity.Property(e => e.PrevzemniNalog)
                .HasComment("Številka prevzemnega naloga")
                .HasColumnName("prevzemni_nalog");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.RazlogPrekinitve)
                .HasMaxLength(200)
                .HasColumnName("razlog_prekinitve");
            entity.Property(e => e.ScadaVnos)
                .HasDefaultValue(true)
                .HasComment("Default na TRUE. Ko vnese nekdo novi RS cez SCADO se ta avtomatsko postavi na TRUE. Ko se RS prenese v PIS se postavi na FALSE.")
                .HasColumnName("SCADA_vnos");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.Skladisce).HasColumnName("skladisce");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Status)
                .HasComment("1=odprt, 2=začetek, 3=točenje, 4=zaključevanje, 5=obdelan, 6=prekinjen")
                .HasColumnName("status");
            entity.Property(e => e.TipPrevoznegaSredstva)
                .HasComment("1=rezervoar, 2=žel. cist, 3=avto cist.")
                .HasColumnName("tip_prevoznega_sredstva");
            entity.Property(e => e.TocilnaPot)
                .HasDefaultValue((byte)0)
                .HasColumnName("Tocilna_pot");
            entity.Property(e => e.TocilnoMesto)
                .HasDefaultValue((byte)0)
                .HasColumnName("Tocilno_mesto");
            entity.Property(e => e.Veljavnost).HasColumnName("veljavnost");
            entity.Property(e => e.Vozilo).HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.VrstaCisterne)
                .HasDefaultValue((byte)0)
                .HasComment("0=mala, 1=velika")
                .HasColumnName("vrsta_cisterne");
            entity.Property(e => e.VrstaPlina).HasColumnName("vrsta_plina");
            entity.Property(e => e.VsebnostC2c4)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_c2c4");
            entity.Property(e => e.VsebnostC3)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_c3");
            entity.Property(e => e.VsebnostDieni)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_dieni");
            entity.Property(e => e.VsebnostOlje)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_olje");
            entity.Property(e => e.VsebnostPp)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_pp");
            entity.Property(e => e.VsebnostZveplo)
                .HasDefaultValue(0f)
                .HasColumnName("vsebnost_zveplo");
        });

        modelBuilder.Entity<ScadaUporabniki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SCADA_Uporabniki");

            entity.Property(e => e.Id)
                .HasComment("Identifikacijska stev. uporabnika")
                .HasColumnName("ID");
            entity.Property(e => e.Uporabnik)
                .HasMaxLength(50)
                .HasComment("Uporabnik SCADA sistem");
        });

        modelBuilder.Entity<TocilnePoti>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tocilne_poti");

            entity.Property(e => e.Id)
                .HasDefaultValue((byte)0)
                .HasComment("ID točilne poti")
                .HasColumnName("ID");
            entity.Property(e => e.IdPrevoznoSredstvo)
                .HasDefaultValue((byte)0)
                .HasComment("ID prevoznega sredstva")
                .HasColumnName("ID_Prevozno_sredstvo");
            entity.Property(e => e.Izdaja)
                .HasDefaultValue(false)
                .HasComment("Se gorivo izdaja?");
            entity.Property(e => e.Opis)
                .HasMaxLength(255)
                .HasComment("Opis točilne poti");
            entity.Property(e => e.Prevzem)
                .HasDefaultValue(false)
                .HasComment("Se gorivo prevzema");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasComment("GUI prikaz");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.TmAp)
                .HasMaxLength(5)
                .HasComment("Točilno mesto avto pretakališča")
                .HasColumnName("TM_AP");
            entity.Property(e => e.TmZp)
                .HasMaxLength(9)
                .HasComment("Točilno mesto železniškega pretakališča")
                .HasColumnName("TM_ZP");
            entity.Property(e => e.VrstaPlina)
                .HasDefaultValue((short)0)
                .HasComment("ID vrsta plina")
                .HasColumnName("Vrsta_plina");
        });

        modelBuilder.Entity<TrosarinskaSkladisca>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Trosarinska_skladisca");

            entity.Property(e => e.Id)
                .HasDefaultValue(0)
                .HasComment("Stevilka skladisca")
                .HasColumnName("ID");
            entity.Property(e => e.Opis)
                .HasMaxLength(100)
                .HasComment("Naziv skladisca")
                .HasColumnName("opis");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<Uporabniki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Uporabniki");

            entity.Property(e => e.Delavec).HasColumnName("delavec");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.ImeInPriimek)
                .HasMaxLength(25)
                .HasColumnName("ime_in_priimek");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
            entity.Property(e => e.Uporabnik).HasColumnName("uporabnik");
            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .HasColumnName("userid");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
        });

        modelBuilder.Entity<Vozila>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .ToTable("Vozila");

            entity.Property(e => e.Dostopnost).HasColumnName("dostopnost");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.KonecVozenj)
                .HasPrecision(0)
                .HasColumnName("KONEC_VOZENJ");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.RegistrskaOznaka)
                .HasMaxLength(10)
                .HasColumnName("registrska_oznaka");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Vozilo)
                .HasDefaultValue(0)
                .HasColumnName("vozilo");
            entity.Property(e => e.Voznik).HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.ZacetekVozenj)
                .HasPrecision(0)
                .HasColumnName("ZACETEK_VOZENJ");
        });

        modelBuilder.Entity<Vozniki>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .ToTable("Vozniki");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.Voznik)
                .HasDefaultValue(0)
                .HasColumnName("voznik");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
        });

        modelBuilder.Entity<VrstePlina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Vrste_plina");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .HasColumnName("opis");
            entity.Property(e => e.Prikaz)
                .HasDefaultValue(true)
                .HasColumnName("prikaz");
            entity.Property(e => e.Sinhronizirano)
                .HasDefaultValue(false)
                .HasColumnName("sinhronizirano");
            entity.Property(e => e.SprDatetime)
                .HasPrecision(0)
                .HasColumnName("spr_datetime");
            entity.Property(e => e.SprUporabnik).HasColumnName("spr_uporabnik");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.VpisDatetime)
                .HasPrecision(0)
                .HasColumnName("vpis_datetime");
            entity.Property(e => e.VpisUporabnik).HasColumnName("vpis_uporabnik");
            entity.Property(e => e.VrstaPlina).HasColumnName("vrsta_plina");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
