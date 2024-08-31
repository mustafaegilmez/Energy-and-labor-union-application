<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="Enerji_İş_Sendikası.Articles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Makaleler</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        body, html {
            margin: 0;
            padding: 0;
            height: 100%;
            overflow: hidden;
        }

        #form1 {
            height: 100%;
        }

        #container1 {
            display: flex;
            flex-direction: column;
            height: 100%;
        }

        #header {
            background-color: #0F125D;
            padding: 15px;
            display: flex;
            align-items: center;
        }

        .btn {
            padding: 10px 15px;
            font-size: 1.5rem;
            min-width: 120px;
            color: #fff;
            border-color: #007bff;
            width: 100px;
            height: 50px;
            border-width: 2px;
            border-style: solid;
            border-radius: 5px;
        }

        
        #GridView1 {
            width: 100%;
            margin-top: 0px;
            border-collapse: collapse;
            border: 1px solid #ddd;
        }

        #GridView1 th,
        #GridView1 td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        #GridView1 tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        #GridView1 th {
            background-color: #007bff;
            color: white;
        }

        
        .content-cell {
            max-height: 450px; 
            overflow-y: auto; 
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="container1">
            <div id="header">
                <asp:Image ID="Image1" runat="server" Height="70px" Width="80px" ImageUrl="https://enerjiis.org.tr/tema/genel/uploads/logo/Enerji-logo.png" BackColor="#CCCCCC" />
                <asp:Label ID="Label1" runat="server" Text="ENERJİ İŞ SENDİKASI" ForeColor="White" Font-Bold="True" Font-Size="Large" style="margin-left: 15px;"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Anasayfa" CssClass="btn btn-primary" style="margin-left: 15px;" BackColor="#0056B3" ForeColor="White" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Makaleler" CssClass="btn btn-primary" style="margin-left: 15px;" BackColor="#0056B3" ForeColor="White" OnClick="Button2_Click" />
                <asp:Button ID="MakaleYaz" runat="server" Text="Makale Yaz" CssClass="btn btn-primary" style="margin-left: 15px;" BackColor="#006600" ForeColor="White" OnClick="MakaleYaz_Click" />
                <div style="margin-left: auto;">
                    <asp:Button ID="Profilim" runat="server" Text="Profilim" CssClass="btn btn-primary" style="margin-left: 15px;" BackColor="#621ED9" ForeColor="White" OnClick="Profilim_Click" />
                    <asp:Button ID="CikisYap" runat="server" Text="Çıkış Yap" CssClass="btn btn-primary" style="margin-left: 15px; height: 46px;" BackColor="#E10D0D" ForeColor="White" OnClick="CikisYap_Click" />
                </div>
            </div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="paylasimlar_isim" HeaderText="BAŞLIK" SortExpression="paylasimlar_isim" />
                    <asp:TemplateField HeaderText="İÇERİK">
                        <ItemTemplate>
                            <div class="content-cell">
                                <asp:Label ID="lblIcerik" runat="server" Text='<%# Eval("paylasimlar_icerik") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="kullanici_isim" HeaderText="YAZAR" SortExpression="kullanici_isim" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sendikaConnectionString3 %>" ProviderName="<%$ ConnectionStrings:sendikaConnectionString3.ProviderName %>" SelectCommand="makale_goster" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>


