using HotelOffersBL.Entities;
using HotelOffersBL.BLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace HotelOffers.Pages
{
    public partial class SearchForOffer : System.Web.UI.Page
    {
        private string ServiceUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["ServiceUrl"] != null)
            {
                ServiceUrl = WebConfigurationManager.AppSettings["ServiceUrl"].ToString();
            }

            if (!Page.IsPostBack)
            {
                HotelOfferBL blObj = new HotelOfferBL();
                List<HotelOffer> lstOffers = new List<HotelOffer>();
                lstOffers = blObj.GetOfferJson(ServiceUrl);
                rptResults.DataSource = lstOffers;
                rptResults.DataBind();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            HotelOfferBL blObj = new HotelOfferBL();
            List<HotelOffer> lstOffers = new List<HotelOffer>();
            string parameter = BuildQueryString();
            lstOffers = blObj.GetOfferJson(ServiceUrl + parameter);
            rptResults.DataSource = lstOffers;
            rptResults.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDestinationCity.Text = string.Empty;
            txtTripStartDate.Text = string.Empty;
            txtTripEndDate.Text = string.Empty;
            txtLengthofStay.Text = string.Empty;
            txtMinStarRating.Text = string.Empty;
            txtMaxStarRating.Text = string.Empty;
            txtMinTotalRate.Text = string.Empty;
            txtMaxTotalRate.Text = string.Empty;
            txtMinGuestRating.Text = string.Empty;
            txtMaxGuestRating.Text = string.Empty;

            rptResults.DataSource = null;
            rptResults.DataBind();

        }

        protected void btnOrderByPrice_Click(object sender, EventArgs e)
        {
            HotelOfferBL blObj = new HotelOfferBL();
            List<HotelOffer> lstOffers = new List<HotelOffer>();
            string parameter = BuildQueryString();
            lstOffers = blObj.GetOfferJson(ServiceUrl + parameter);
            string orderBy = "Price";
            rptResults.DataSource = OrderList(lstOffers, orderBy, true);
            rptResults.DataBind();
        }

        protected void btnOrderByGuestRating_Click(object sender, EventArgs e)
        {
            HotelOfferBL blObj = new HotelOfferBL();
            List<HotelOffer> lstOffers = new List<HotelOffer>();
            string parameter = BuildQueryString();
            lstOffers = blObj.GetOfferJson(ServiceUrl + parameter);
            string orderBy = "GuestReviewRating";
            rptResults.DataSource = OrderList(lstOffers, orderBy, false);
            rptResults.DataBind();
        }

        protected void btnOrderByName_Click(object sender, EventArgs e)
        {
            HotelOfferBL blObj = new HotelOfferBL();
            List<HotelOffer> lstOffers = new List<HotelOffer>();
            string parameter = BuildQueryString();
            lstOffers = blObj.GetOfferJson(ServiceUrl + parameter);
            string orderBy = "HotelName";
            rptResults.DataSource = OrderList(lstOffers, orderBy, true);
            rptResults.DataBind();
        }

        private List<HotelOffer> OrderList(List<HotelOffer> lst, string orderBy, bool isAscending)
        {
            var orderByString = String.IsNullOrEmpty(orderBy) ? "HotelName" : orderBy;
            var dynamicPropFromStr = typeof(HotelOffer).GetProperty(orderByString);
            if (isAscending)
            {
                return lst = lst.OrderBy(att => dynamicPropFromStr.GetValue(att, null)).ToList();
            }
            else
            {
                return lst = lst.OrderByDescending(att => dynamicPropFromStr.GetValue(att, null)).ToList();
            }
        }

        private string BuildQueryString()
        {
            StringBuilder parametereSB = new StringBuilder();
            if (!string.IsNullOrEmpty(txtDestinationCity.Text))
            {
                parametereSB.Append("&destinationCity=" + txtDestinationCity.Text);
            }
            if (!string.IsNullOrEmpty(txtTripStartDate.Text))
            {
                parametereSB.Append("&minTripStartDate=" + txtTripStartDate.Text);
            }
            if (!string.IsNullOrEmpty(txtTripEndDate.Text))
            {
                parametereSB.Append("&maxTripStartDate=" + txtTripEndDate.Text);
            }
            if (!string.IsNullOrEmpty(txtLengthofStay.Text))
            {
                parametereSB.Append("&lengthOfStay=" + txtLengthofStay.Text);
            }
            if (!string.IsNullOrEmpty(txtMinStarRating.Text))
            {
                parametereSB.Append("&minStarRating=" + txtMinStarRating.Text);
            }
            if (!string.IsNullOrEmpty(txtMaxStarRating.Text))
            {
                parametereSB.Append("&maxStarRating=" + txtMaxStarRating.Text);
            }
            if (!string.IsNullOrEmpty(txtMinTotalRate.Text))
            {
                parametereSB.Append("&minTotalRate=" + txtMinTotalRate.Text);
            }
            if (!string.IsNullOrEmpty(txtMaxTotalRate.Text))
            {
                parametereSB.Append("&maxTotalRate=" + txtMaxTotalRate.Text);
            }
            if (!string.IsNullOrEmpty(txtMinGuestRating.Text))
            {
                parametereSB.Append("&minGuestRating=" + txtMinGuestRating.Text);
            }
            if (!string.IsNullOrEmpty(txtMaxGuestRating.Text))
            {
                parametereSB.Append("&maxGuestRating=" + txtMaxGuestRating.Text);
            }
            return parametereSB.ToString();
        }
    }
}