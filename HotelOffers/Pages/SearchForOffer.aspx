<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SearchForOffer.aspx.cs" Inherits="HotelOffers.Pages.SearchForOffer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Find Offer</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group col-xs-4 col-md-4">
        <asp:Label ID="lblDestinationCity" runat="server" Text="Destination City" class="control-label"></asp:Label>
        <asp:TextBox ID="txtDestinationCity" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblTripStartDate" runat="server" Text="Trip Start Date" class="control-label"></asp:Label>
        <asp:TextBox ID="txtTripStartDate" runat="server" class="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTripStartDate" ControlToValidate="txtTripStartDate" ValidationExpression="^[1-9][0-9][0-9][0-9]-(0\d|10|11|12)-(0\d|1\d|2\d|3[0-1])$" runat="server" ErrorMessage="Please Enter Correct Date with format YYYY-MM-dd" ValidationGroup="search" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblTripEndDate" runat="server" Text="Trip End Date" class="control-label"></asp:Label>
        <asp:TextBox ID="txtTripEndDate" runat="server" class="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revTripEndDate" ControlToValidate="txtTripEndDate" ValidationExpression="^[1-9][0-9][0-9][0-9]-(0\d|10|11|12)-(0\d|1\d|2\d|3[0-1])$" runat="server" ErrorMessage="Please Enter Correct Date with format YYYY-MM-dd" ValidationGroup="search" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
    </div>

    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblLengthofStay" runat="server" Text="length of stay" class="control-label"></asp:Label>
        <asp:TextBox ID="txtLengthofStay" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMinStarRating" runat="server" Text="Min Star Rating" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMinStarRating" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMaxStarRating" runat="server" Text="Max Star Rating" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMaxStarRating" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMinTotalRate" runat="server" Text="Min Total Rate" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMinTotalRate" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMaxTotalRate" runat="server" Text="Max Total Rate" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMaxTotalRate" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMinGuestRating" runat="server" Text="Min Guest Rating" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMinGuestRating" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class=" form-group col-xs-4 col-md-4">
        <asp:Label ID="lblMaxGuestRating" runat="server" Text="Max Guest Rating" class="control-label"></asp:Label>
        <asp:TextBox ID="txtMaxGuestRating" runat="server" class="form-control"></asp:TextBox>
    </div>

    <div class="clearfix">
    </div>

    <div class=" form-group col-xs-4 col-md-4">
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Cleare" OnClick="btnReset_Click" />
    </div>

    <div class="clearfix">
    </div>

    <div class=" form-group col-xs-12 col-md-12">
        <p>Order By: </p>
        <asp:Button ID="btnOrderByPrice" runat="server" Text="Price" CssClass="btn btn-primary" OnClick="btnOrderByPrice_Click" />
        <asp:Button ID="btnOrderByGuestRating" runat="server" Text="Guest Rating" CssClass="btn btn-primary" OnClick="btnOrderByGuestRating_Click" />
        <asp:Button ID="btnOrderByName" runat="server" Text="Hotel Name" CssClass="btn btn-primary" OnClick="btnOrderByName_Click" />
    </div>

    <div class="clearfix">
    </div>


    <div class="well search-result">
        <asp:Repeater ID="rptResults" runat="server">
            <ItemTemplate>
                <div class="row" style="margin-top: 5px; border-style: double !important;">
                    <a href='<%# Eval("HotelUrl") %>'>
                        <div class="col-xs-6 col-sm-3 col-md-3 col-lg-2">
                            <img class="img-responsive" src='<%# Eval("HotelImageUrl") %>' style="margin-top: 15px; margin-left: 15px;">
                        </div>
                        <div class="col-xs-6 col-sm-9 col-md-9 col-lg-10 title">
                            <h3>
                                <asp:Literal ID="ltrName" runat="server" Text='<%# Eval("HotelName") %>'></asp:Literal></h3>
                            <p>
                                Star Rating:       
                                    <asp:Literal ID="ltrStarRating" runat="server" Text='<%# Eval("StarRating") %>'></asp:Literal>
                            </p>
                            <p>Guest Review Rating:<asp:Literal ID="ltrGuestReviewRating" runat="server" Text='<%# Eval("GuestReviewRating") %>'></asp:Literal></p>
                            <p>
                                Total Reviews:     
                                    <asp:Literal ID="ltrTotalReview" runat="server" Text='<%# Eval("TotalReview") %>'></asp:Literal>
                            </p>
                            <p>
                                Price:             
                                    <asp:Literal ID="ltrPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Literal>
                            </p>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
