using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPartyCatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopDecorations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Decorations(Title, Description, UrlImage, DecoratorId) " +
                "Values('Mickey', 'Festa do Mickey', 'mickey.jpg', 1)");

            mb.Sql("Insert into Decorations(Title, Description, UrlImage, DecoratorId) " +
                "Values('Hotweels', 'Festa da Hotweels', 'hotweels.jpg', 2)");

            mb.Sql("Insert into Decorations(Title, Description, UrlImage, DecoratorId) " +
                "Values('Sonic', 'Festa do Sonic', 'sonic.jpg', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Decorations");
        }
    }
}
