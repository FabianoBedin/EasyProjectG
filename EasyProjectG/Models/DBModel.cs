namespace EasyProjectG.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<agenda> agenda { get; set; }
        public virtual DbSet<atividade> atividade { get; set; }
        public virtual DbSet<demanda> demanda { get; set; }
        public virtual DbSet<demandaHistorico> demandaHistorico { get; set; }
        public virtual DbSet<entidade> entidade { get; set; }
        public virtual DbSet<etapa> etapa { get; set; }
        public virtual DbSet<fornecedor> fornecedor { get; set; }
        public virtual DbSet<funcao> funcao { get; set; }
        public virtual DbSet<indicador> indicador { get; set; }
        public virtual DbSet<indicadorDado> indicadorDado { get; set; }
        public virtual DbSet<label> label { get; set; }
        public virtual DbSet<material> material { get; set; }
        public virtual DbSet<meta> meta { get; set; }
        public virtual DbSet<movFinanceira> movFinanceira { get; set; }
        public virtual DbSet<nota> nota { get; set; }
        public virtual DbSet<nucleo> nucleo { get; set; }
        public virtual DbSet<patrimonio> patrimonio { get; set; }
        public virtual DbSet<pessoa> pessoa { get; set; }
        public virtual DbSet<projeto> projeto { get; set; }
        public virtual DbSet<projetoAquisicao> projetoAquisicao { get; set; }
        public virtual DbSet<projetoEntidade> projetoEntidade { get; set; }
        public virtual DbSet<projetoMaterial> projetoMaterial { get; set; }
        public virtual DbSet<projetoPessoa> projetoPessoa { get; set; }
        public virtual DbSet<projetoRecurso> projetoRecurso { get; set; }
        public virtual DbSet<recurso> recurso { get; set; }
        public virtual DbSet<setor> setor { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tag> tag { get; set; }
        public virtual DbSet<tarefa> tarefa { get; set; }
        public virtual DbSet<tipo> tipo { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agenda>()
                .Property(e => e.agendaHoraInicio)
                .IsUnicode(false);

            modelBuilder.Entity<agenda>()
                .Property(e => e.agendaHoraFinal)
                .IsUnicode(false);

            modelBuilder.Entity<agenda>()
                .Property(e => e.agendaCor)
                .IsUnicode(false);

            modelBuilder.Entity<atividade>()
                .Property(e => e.atividadeNome)
                .IsUnicode(false);

            modelBuilder.Entity<atividade>()
                .Property(e => e.atividadeDescricao)
                .IsUnicode(false);

            modelBuilder.Entity<atividade>()
                .Property(e => e.atividadeCor)
                .IsUnicode(false);

            modelBuilder.Entity<atividade>()
                .Property(e => e.atividadeUN)
                .IsFixedLength();

            modelBuilder.Entity<atividade>()
                .HasMany(e => e.nota)
                .WithOptional(e => e.atividade)
                .HasForeignKey(e => e.nota_atividadeId);

            modelBuilder.Entity<atividade>()
                .HasMany(e => e.tarefa)
                .WithOptional(e => e.atividade)
                .HasForeignKey(e => e.tarefa_atividadeId);

            modelBuilder.Entity<demanda>()
                .Property(e => e.demandaManterAtivo)
                .IsFixedLength();

            modelBuilder.Entity<demanda>()
                .HasMany(e => e.demandaHistorico1)
                .WithRequired(e => e.demanda)
                .HasForeignKey(e => e.demandaHistorico_demandaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entidade>()
                .Property(e => e.entidadeDesativado)
                .IsFixedLength();

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.demanda)
                .WithRequired(e => e.entidade)
                .HasForeignKey(e => e.demanda_entidadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.pessoa)
                .WithRequired(e => e.entidade)
                .HasForeignKey(e => e.pessoa_entidadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.projeto)
                .WithOptional(e => e.entidade)
                .HasForeignKey(e => e.projetoGestora_entidadeId);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.projetoEntidade)
                .WithRequired(e => e.entidade)
                .HasForeignKey(e => e.projetoEntidade_entidadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.recurso)
                .WithOptional(e => e.entidade)
                .HasForeignKey(e => e.recurso_entidadeId);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.setor)
                .WithRequired(e => e.entidade)
                .HasForeignKey(e => e.setor_entidadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<entidade>()
                .HasMany(e => e.tag)
                .WithMany(e => e.entidade)
                .Map(m => m.ToTable("entidadeTag").MapLeftKey("entidadeId").MapRightKey("tagId"));

            modelBuilder.Entity<etapa>()
                .Property(e => e.etapaNome)
                .IsUnicode(false);

            modelBuilder.Entity<etapa>()
                .Property(e => e.etapaDescricao)
                .IsUnicode(false);

            modelBuilder.Entity<etapa>()
                .Property(e => e.etapaFlagConcluido)
                .IsFixedLength();

            modelBuilder.Entity<etapa>()
                .HasMany(e => e.atividade)
                .WithRequired(e => e.etapa)
                .HasForeignKey(e => e.atividade_etapaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<fornecedor>()
                .HasMany(e => e.projetoAquisicao)
                .WithOptional(e => e.fornecedor)
                .HasForeignKey(e => e.projetoAquisicao_fornecedorId);

            modelBuilder.Entity<funcao>()
                .HasMany(e => e.projetoPessoa)
                .WithOptional(e => e.funcao)
                .HasForeignKey(e => e.projetoPessoa_funcaoId);

            modelBuilder.Entity<indicador>()
                .Property(e => e.indicadorPlanejado)
                .IsFixedLength();

            modelBuilder.Entity<indicador>()
                .Property(e => e.indicadorInformado)
                .IsFixedLength();

            modelBuilder.Entity<indicador>()
                .Property(e => e.indicadorUnidadeMedida)
                .IsFixedLength();

            modelBuilder.Entity<indicador>()
                .HasMany(e => e.indicadorDado)
                .WithRequired(e => e.indicador)
                .HasForeignKey(e => e.indicadorDado_indicadorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<indicadorDado>()
                .Property(e => e.indicadorStatus)
                .IsFixedLength();

            modelBuilder.Entity<material>()
                .Property(e => e.materialUnidadeMedida)
                .IsFixedLength();

            modelBuilder.Entity<material>()
                .HasMany(e => e.projetoMaterial)
                .WithRequired(e => e.material)
                .HasForeignKey(e => e.projetoMaterial_materialId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<meta>()
                .HasMany(e => e.atividade)
                .WithOptional(e => e.meta)
                .HasForeignKey(e => e.atividade_metaId);

            modelBuilder.Entity<movFinanceira>()
                .Property(e => e.movFinanceiraReceita)
                .IsFixedLength();

            modelBuilder.Entity<nota>()
                .Property(e => e.notaDesc)
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaTitulo)
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaCorFundo)
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaAgenda)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notastatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaLabels)
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaChecklist)
                .IsUnicode(false);

            modelBuilder.Entity<nota>()
                .Property(e => e.notaId2)
                .IsUnicode(false);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.agenda)
                .WithOptional(e => e.nucleo)
                .HasForeignKey(e => e.agenda_nucleoId);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.entidade)
                .WithRequired(e => e.nucleo)
                .HasForeignKey(e => e.entidade_nucleoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.indicador)
                .WithRequired(e => e.nucleo)
                .HasForeignKey(e => e.indicador_nucleoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.label)
                .WithRequired(e => e.nucleo)
                .HasForeignKey(e => e.label_nucleoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.movFinanceira)
                .WithRequired(e => e.nucleo)
                .HasForeignKey(e => e.movFinanceira_nucleoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.status)
                .WithOptional(e => e.nucleo)
                .HasForeignKey(e => e.status_nucleoId);

            modelBuilder.Entity<nucleo>()
                .HasMany(e => e.usuario)
                .WithRequired(e => e.nucleo)
                .HasForeignKey(e => e.usuario_nucleoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patrimonio>()
                .Property(e => e.patrimonioDoc)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa>()
                .Property(e => e.pessoaDesativado)
                .IsFixedLength();

            modelBuilder.Entity<pessoa>()
                .HasMany(e => e.projeto)
                .WithRequired(e => e.pessoa)
                .HasForeignKey(e => e.projetoResp_pessoaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa>()
                .HasMany(e => e.projetoPessoa)
                .WithRequired(e => e.pessoa)
                .HasForeignKey(e => e.projetoPessoa_pessoaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa>()
                .HasMany(e => e.tarefa)
                .WithOptional(e => e.pessoa)
                .HasForeignKey(e => e.tarefa_pessoaId);

            modelBuilder.Entity<pessoa>()
                .HasMany(e => e.usuario)
                .WithOptional(e => e.pessoa)
                .HasForeignKey(e => e.usuario_pessoaId);

            modelBuilder.Entity<projeto>()
                .Property(e => e.projetoCompartilhado)
                .IsFixedLength();

            modelBuilder.Entity<projeto>()
                .Property(e => e.projetoPasta)
                .IsUnicode(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.agenda)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.agenda_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.atividade)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.atividade_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.etapa)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.etapa_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.indicador)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.indicador_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.meta)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.meta_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.movFinanceira)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.movFinaceira_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.nota)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.nota_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.projetoAquisicao)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.projetoAquisicao_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.projetoEntidade)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.projetoEntidade_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.projetoMaterial)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.projetoMaterial_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.projetoPessoa)
                .WithOptional(e => e.projeto)
                .HasForeignKey(e => e.projetoPessoa_projetoId);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.projetoRecurso)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.projetoRecurso_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.tarefa)
                .WithRequired(e => e.projeto)
                .HasForeignKey(e => e.tarefa_projetoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<projeto>()
                .HasMany(e => e.tag)
                .WithMany(e => e.projeto)
                .Map(m => m.ToTable("projetoTag").MapLeftKey("projetoId").MapRightKey("tagId"));

            modelBuilder.Entity<projetoAquisicao>()
                .HasOptional(e => e.patrimonio)
                .WithRequired(e => e.projetoAquisicao);

            modelBuilder.Entity<projetoMaterial>()
                .Property(e => e.projetoMaterialContraPartida)
                .IsFixedLength();

            modelBuilder.Entity<projetoPessoa>()
                .Property(e => e.projetoPessoaContrapartida)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<projetoPessoa>()
                .Property(e => e.projetoPessoaConta)
                .IsUnicode(false);

            modelBuilder.Entity<projetoRecurso>()
                .Property(e => e.projetoRecursoContrapartida)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<projetoRecurso>()
                .Property(e => e.projetoRecursoConta)
                .IsUnicode(false);

            modelBuilder.Entity<recurso>()
                .HasMany(e => e.projetoRecurso)
                .WithRequired(e => e.recurso)
                .HasForeignKey(e => e.projetoRecurso_recursoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaNome)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaTitulo)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaCorFundo)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaAgenda)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefastatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaLabels)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaChecklist)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaID2)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.tarefaPrioridade)
                .IsUnicode(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.entidade)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.entidade_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.indicador)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.indicador_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.label)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.label_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.nucleo)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.nucleo_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.projeto)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.projeto_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.projetoPessoa)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.projetoPessoa_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.recurso)
                .WithOptional(e => e.tipo)
                .HasForeignKey(e => e.recurso_tipoId);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.status)
                .WithRequired(e => e.tipo)
                .HasForeignKey(e => e.status_tipoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.tag)
                .WithOptional(e => e.tipo)
                .HasForeignKey(e => e.tag_tipoId);

            modelBuilder.Entity<tipo>()
                .HasMany(e => e.usuario)
                .WithOptional(e => e.tipo)
                .HasForeignKey(e => e.usuarioNivel_tipoId);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.nota)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.nota_usuarioId);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.tarefa)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.tarefa_usuarioId);
        }
    }
}
