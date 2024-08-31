<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakaleYaz.aspx.cs" Inherits="Enerji_İş_Sendikası.MakaleYaz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
        <style>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 10px; /* Küçük bir padding */
    background-color: #f4f4f4;
}

.container {
    max-width: 600px; /* Container genişliği küçültüldü */
    margin: 0 auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 5px;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.blog-post {
    padding: 15px; /* Padding küçültüldü */
    border-bottom: 1px solid #ddd;
}

/* Başlık giriş kutusu */
.title-input {
    width: 100%;
    padding: 8px; /* Padding küçültüldü */
    font-size: 1em; /* Font boyutu standart hale getirildi */
    border: 1px solid #ddd;
    border-radius: 3px; /* Border radius küçültüldü */
    margin-bottom: 10px;
}

/* Makale içeriği giriş kutusu */
.content-input {
    width: 100%;
    min-height: 300px; /* Kutu yüksekliği küçültüldü */
    padding: 10px; /* Padding küçültüldü */
    font-size: 0.9em; /* Font boyutu küçültüldü */
    font-family: Arial, sans-serif;
    resize: vertical;
    border: 1px solid #ddd;
    border-radius: 3px; /* Border radius küçültüldü */
    margin-bottom: 15px; /* Alt boşluk artırıldı */
}

/* Gönder düğmesi */
.btn {
    background-color: #333;
    color: #fff;
    padding: 8px 15px; 
    border: none;
    border-radius: 3px; 
    cursor: pointer;
    transition: background-color 0.2s ease-in-out;
}

.btn:hover {
    background-color:cornflowerblue ;
}
        </style>
</head>
    
<body>
    <form id="form1" runat="server">
       <div class="container">
    <div class="blog-post">
        <h2>Başlık</h2>
        <asp:TextBox ID="TextBoxTitle" runat="server" Text="BAŞLIK GİRİNİZ"  CssClass="title-input" />
        <h2>Makale Yazısı</h2>
        <div class="content">
            <asp:TextBox ID="TextBoxContent" runat="server" Text="MAKALE YAZISI" TextMode="MultiLine" Rows="10" CssClass="content-input" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Gönder" CssClass="btn" OnClick="paylas_Click" />
        
   
      
        <asp:Button ID="Button2" runat="server" style="margin-left:65%;background-color:red ;" CssClass="btn" OnClick="Button2_Click1" Text="Geri Dön" />
        
   
    </div>
</div>
       
    </form>
</body>
</html>
