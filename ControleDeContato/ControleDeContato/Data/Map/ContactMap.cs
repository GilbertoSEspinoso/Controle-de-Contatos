using ControleDeContato.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


//mapeamento dos contatos
namespace ControleDeContato.Data.Map
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            //informando que o Id é a chave primaria da entidade contato
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }
    }
}
