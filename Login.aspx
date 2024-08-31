<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enerji_İş_Sendikası.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Giriş Yap</title>
 <style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 100vh;
    }

    .container {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .logo, .form-container {
        margin-bottom: 20px;
    }

    .form-container {
        background-color: #fff;
        padding: 40px;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .form-group {
        margin-bottom: 20px;
    }

    .form-group label {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
    }

    .form-group input[type="text"],
    .form-group input[type="password"],
    .form-group input[type="email"] {
        width: calc(100% - 22px);
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 3px;
        font-size: 16px;
        box-sizing: border-box;
    }

    .form-group input[type="submit"] {
        width: 100%;
        padding: 10px;
        border: none;
        border-radius: 3px;
        font-size: 16px;
        background-color: #007bff;
        color: #fff;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    .form-group input[type="submit"]:hover {
        background-color: #0056b3;
    }

    .welcome-message {
        font-size: 24px;
        font-weight: bold;
        color: #007bff;
        text-align: center;
        margin-bottom: 20px;
    }
     .home-button {
     position: absolute; /* Anasayfa butonunun konumunu belirlemek için */
     top: 20px; /* Üstten 20 piksel mesafede */
     left: 20px; /* Soldan 20 piksel mesafede */
     padding: 10px 20px;
     background-color: #007bff;
     color: #fff;
     text-decoration: none;
     border-radius: 5px;
     transition: background-color 0.3s;
 }

 .home-button:hover {
     background-color: #0056b3;
 }
</style>
</head>
<body>
     <div class="container">
     <div class="logo">
          <a href="AnaSayfa.aspx" class="home-button">Anasayfa</a>
         <img src="https://www.enerjiis.org.tr/tema/genel/uploads/logo/Enerji-logo.png" alt="Logo" /> 
     </div>
     <div class="form-container">
         <div class="welcome-message">
             Enerji İş Sendikasına Hoşgeldiniz
         </div>
         <form id="form1" runat="server">
             <div class="form-group">
                 <asp:Label ID="Label1" runat="server" Text="E-posta"></asp:Label>
                 <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
             </div>
             <div class="form-group">
                 <asp:Label ID="Label2" runat="server" Text="Parola"></asp:Label>
                 <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
             </div>
             <div class="form-group">
                 <asp:Button ID="Button1" runat="server" Text="Giriş Yap" OnClick="Button1_Click" /> 
                 <br />
                 <br />
                 <asp:Button style="background-color:green" ID="Button2" runat="server" Text="Admin Giriş" OnClick="Button2_Click" /> 
                 <br />
                 <br />
                 <asp:Label ID="Label3" runat="server"></asp:Label>
             </div>
         </form>
     </div>
 </div>
</body>
</html>
