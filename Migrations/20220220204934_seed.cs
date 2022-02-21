using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Trinks.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                IF NOT EXISTS(SELECT * FROM dbo.Client c WHERE c.Id IN (1,2))
                BEGIN
                    INSERT INTO dbo.Client
                    (
                        --Id - column value is auto-generated
                        Name,
                        CNPJ,
                        [State]
                    )
                    VALUES
                    (
                        -- Id - int
                        'Empresa A', -- Name - nvarchar
                        '00000000001', -- CNPJ - nvarchar
                        'RJ' -- State - nvarchar
                    )

                    INSERT INTO dbo.Client
                    (
                        --Id - column value is auto-generated
                        Name,
                        CNPJ,
                        [State]
                    )
                    VALUES
                    (
                        -- Id - int
                        'Empresa B', -- Name - nvarchar
                        '00000000002', -- CNPJ - nvarchar
                        'SP' -- State - nvarchar
                    )
                END

                DECLARE @clientId INT;
                SELECT @clientId = c.Id
                FROM dbo.Client c
                WHERE c.Name = 'Empresa A';

                IF NOT EXISTS (SELECT * FROM dbo.Process p WHERE p.Id IN (1,2,3,4,5,6,7,8,9,10))
                BEGIN
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00001CIVELRJ', -- ProcessNumber - nvarchar
                        'RJ', -- State - nvarchar
                        200000, -- MonetaryValue - real
                        '2007-10-10 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00002CIVELSP', -- ProcessNumber - nvarchar
                        'SP', -- State - nvarchar
                        100000, -- MonetaryValue - real
                        '2007-10-20 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        0, -- Active - bit
                        '00003TRABMG', -- ProcessNumber - nvarchar
                        'MG', -- State - nvarchar
                        10000, -- MonetaryValue - real
                        '2007-10-30 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        0, -- Active - bit
                        '00004CIVELRJ', -- ProcessNumber - nvarchar
                        'RJ', -- State - nvarchar
                        20000, -- MonetaryValue - real
                        '2007-11-10 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00005CIVELSP', -- ProcessNumber - nvarchar
                        'SP', -- State - nvarchar
                        35000, -- MonetaryValue - real
                        '2007-11-15 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00005CIVELSP', -- ProcessNumber - nvarchar
                        'SP', -- State - nvarchar
                        35000, -- MonetaryValue - real
                        '2007-11-15 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );

                    SELECT @clientId = c.Id
                    FROM dbo.Client c
                    WHERE c.Name = 'Empresa B';
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00006CIVELRJ', -- ProcessNumber - nvarchar
                        'RJ', -- State - nvarchar
                        20000, -- MonetaryValue - real
                        '2007-05-01 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00007CIVELRJ', -- ProcessNumber - nvarchar
                        'RJ', -- State - nvarchar
                        700000, -- MonetaryValue - real
                        '2007-06-02 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        0, -- Active - bit
                        '00008CIVELSP', -- ProcessNumber - nvarchar
                        'SP', -- State - nvarchar
                        500, -- MonetaryValue - real
                        '2007-07-03 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        1, -- Active - bit
                        '00009CIVELSP', -- ProcessNumber - nvarchar
                        'SP', -- State - nvarchar
                        32000, -- MonetaryValue - real
                        '2007-08-04 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                    INSERT INTO dbo.Process
                    (
                        --Id - column value is auto-generated
                        Active,
                        ProcessNumber,
                        [State],
                        MonetaryValue,
                        StartDate,
                        ClientId
                    )
                    VALUES
                    (
                        -- Id - int
                        0, -- Active - bit
                        '00010TRABAM', -- ProcessNumber - nvarchar
                        'AM', -- State - nvarchar
                        1000, -- MonetaryValue - real
                        '2007-09-05 00:00:00.000', -- StartDate - datetime2
                        @clientId -- ClientId - int
                    );
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
