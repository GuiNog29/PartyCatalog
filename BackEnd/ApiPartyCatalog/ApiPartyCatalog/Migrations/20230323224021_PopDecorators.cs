using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPartyCatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopDecorators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Decorators(NameDecorator, Email, Password) Values('Guilherme', 'guilherme@gmail.com', '123')");
            mb.Sql("Insert into Decorators(NameDecorator, Email, Password) Values('Carlos', 'carlos@gmail.com', '123')");
            mb.Sql("Insert into Decorators(NameDecorator, Email, Password) Values('Julia', 'julia@gmail.com', '123')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Decorators");
        }
    }
}
