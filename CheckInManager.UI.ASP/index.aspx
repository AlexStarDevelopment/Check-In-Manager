<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CheckInManager.UI.ASP.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en-gb" dir="ltr">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Loaves and Fishes Check-In</title>
    
    <link rel="stylesheet" href="/Content/CheckInSite.css"  />

    <link rel="stylesheet" href="/Content/customercss/custom.scss" />

        <link rel="stylesheet" href="/Content/css/font-awesome/font-awesome.css"  />
    <link rel="stylesheet" href="/Content/css/bootstrap.css"  />
</head>
<body>
      <%-- Big Blue Bar across top of screen --%>

<form id="form1" runat="server">
       <div class="container-fluid" style="background: linear-gradient(to bottom, rgba(255,255,255,0.15) 0%, rgba(1,160,250,0.15) 100%), radial-gradient(at top center, rgba(255,255,255,0.40) 0%, rgba(1,160,250,0.40) 120%) #1393ad;" "background-blend-mode: multiply,multiply;">
            <nav class="navbar navbar-expand-lg navbar-light">
                   <a class="navbar-brand" href="#">Loaves & Fishes</a>
                   <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                   </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mt-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#">Create New Event</a>
                    </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">Dashboard</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Login</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                </ul>
                  <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Close Event</button>
            </div>
            </nav>
        </div>
  
        <%-- START OF BODY --%>

<div class="container">
    <div class="row">
        <div class="card">
            <div class="card-body">
                <div class="form-check form-check-inline">
                    <div class="col">
                        <input type="hidden" id="female" class="form-check-input" name="female" value="female" /><img src="images/woman.svg" onclick="#female">
                        <label class="form-check-label" for="female"></label>
                    </div>
                </div>
                <div class="form-check form-check-inline">
                    <div class="col">
                        <input type="hidden" id="male" class="form-check-input" name="male" value="male" /><img src="images/man.svg" onclick="#male">
                        <label class="form-check-label" for="male"></label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



         
 

        <div class="scontainer" id="second">

        <div class="card text-center" style="width:13rem"><img src="images/child.svg" style="width: 100%">
            <div class="card-body" style="height:4rem;">
                <h1 class="card-title">Child</h1>
            </div>
        </div>

        <div class="card text-center" style="width:13rem"><img src="images/senior.svg" style="width: 100%">
            <div class="card-body" style="height:4rem;">
                <h1 class="card-title">Adult</h1>
            </div>
        </div>

             <div class="card text-center" style="width:13rem"><img src="images/adult.svg" style="width: 100%">
            <div class="card-body" style="height:4rem;">
                <h1 class="card-title">Senior</h1>
            </div>
        </div>

    </div>


   
     
          <%-- Ethnicity Buttons --%>


<%--    <div class="scontainer" id="third">
            <div class="col-sm-4">
                <div class="btn-group btn-group-toggle btn-group-lg" data-toggle="buttons">
                    <label class="btn btn-secondary active">
                        <input type="radio" name="native" id="1"/>Native American
                    </label>
                </div>
            </div>
        <div class="col-sm-4">
            <div class="btn-group btn-group-toggle btn-group-lg" data-toggle="buttons">
                <label class="btn btn-secondary active">
                    <input type="radio" name="african" id="2"/>African American
                </label>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="btn-group btn-group-toggle btn-group-lg" data-toggle="buttons">
                <label class="btn btn-secondary active">
                    <input type="radio" name="hispanic" id="3"/>Hispanic
                </label>
            </div>
        </div>
    </div>



            <div class="col-sm-4">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">African American</a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Hispanic</a>
                </div>
            </div>
       
    

            <br />
        

    <div class="container-fluid">
        <div class="uk-flex-row">
            <div class="col-sm-4">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Asian American</a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">White</a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Other</a>
                </div>
            </div>
        </div>
    </div>
</div>

    
  
        <p> &nbsp; </p> 



          City Buttons


<div class="group5">
    <div class="container-fluid">
        <div class="uk-flex-row">
            <div class="col-sm-4 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Menasha</a>
                </div>
            </div>

            <div class="col-sm-4 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Kimberly</a>
                </div>
            </div>

            <div class="col-sm-4 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Kaukauna</a>
                </div>
            </div>

            <div class="col-sm-4 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Little Chute</a>
                </div>
            </div>

            <div class="col-sm-4 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Neenah</a>
                </div>
            </div>

            <div class="col-sm-6 col-md-4 col-lg-2">
                <div class="btn-group btn-group-justified btn-group-lg">
                    <a href="#" class="btn btn-default liner">Other</a>
                </div>
            </div>
        </div>
    </div>
</div>

   
    <p> &nbsp; </p>

    <div class="uk-section uk-padding-remove uk-text-center">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-offset-5 col-sm-2 col-sm-offset-5">
                    <button type="button" name="submitbtn" id="submitbtn" class="uk-button uk-button-primary uk-button-large btn-block btn-font" data-toggle="modal" data-target="#myModal" onclick="addcount()">Submit</button>
                </div>
            </div>
        </div>
    </div>
</div>



            <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="alert alert-success">
                        <strong>Success!</strong> You were successfully added.
                    </div>
                    <div class="alert alert-warning">
                        <strong>Oops!</strong> Something went wrong. Please resubmit your entry.
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>--%>
   </form>

    <script src="/Content/js/jquery.js"></script>
    <script src="/Content/js/bootstrap.bundle.js"></script>
    <script src="/Content/js/checkinmanager.js"></script>  
</body>


</html>



