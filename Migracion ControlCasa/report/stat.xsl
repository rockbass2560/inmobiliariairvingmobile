<?xml version="1.0" ?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>

  <xsl:template match="/">

    <HTML>
      <HEAD>

        <LINK REL='stylesheet' HREF="../textstyles.css" type="text/css"></LINK>


        <script language="javascript">

          function init()
          {

          try
          {

          var height = top.getCatHeight();
          h = height - 350;
          var eDiv = document.getElementById("innerDiv");

          var str = window.parent.document.location.toString();
          if (str.lastIndexOf("srcIndex")>0)
          h-=35;
          eDiv.style.height = h;
          }
          catch(e)
          {
          var eDiv = document.getElementById("innerDiv");
          eDiv.style.height = "100%";
          eDiv.style.overflowY='visible';
          }
          }

          var lastTimeoutId=null;

          function doResize()
          {
          if (lastTimeoutId != null)
          clearTimeout(lastTimeoutId);
          lastTimeoutId = setTimeout("checkSize()",50);

          }

          function checkSize()
          {
          try
          {
          var height = top.getCatHeight();
          h = height - 185;
          var eDiv = document.getElementById("innerDiv");

          var str = window.parent.document.location.toString();
          if (str.lastIndexOf("srcIndex")>0)
          h-=35;

          var mh = top.getMessagesHeight();
          h -= mh;
          eDiv.style.height = h;
          }
          catch(e)
          {
          //just ignore
          }

          }

          function foo(s){

          alert("aaa");
          return 1;

          }
        </script>


      </HEAD>
      <TITLE></TITLE>
      <BODY bgcolor="white" STYLE='height:100%;width=100%;text-align:center' onload='javascript:init();' onresize='javascript:doResize();'>

        <table STYLE='table-layout:fixed;width=380;' >
          <tr >
            <td STYLE='background-color:white;border-style:none' >
          <!--
	<div HEIGHT='50' align='center' valign='middle' color="white" STYLE='table-layout:fixed;border-collapse:collapse;'><b> Conversion statistics</b> </div>-->

          <div id='mainDiv' align = "center" STYLE='width=355;'>
            <table ID='st_head' align='center' STYLE='table-layout:fixed;border-collapse:collapse;width:355'>
              <caption>
                <div HEIGHT='50' align='center' valign='middle' color="white">
                  <b> Conversion statistics</b>
                </div>
              </caption>
              <col style='width:140'></col>
              <col style='width:55'></col>
              <col style='width:80'></col>
              <col style='width:80'></col>
              <tr HEIGHT='35' >
                <th> Statement type</th>
                <th> Total</th>
                <th> Converted</th>
                <th> Not converted</th>
              </tr>
            </table>
          </div>

          <div id='innerDiv' STYLE='height:75%;width:355;overflow-y:auto;'>
            <table ID='st_head' align='center' STYLE='table-layout:fixed;border-collapse:collapse;width:355;'>
              <div STYLE='margin:0;overflow-y:auto'>
              <xsl:for-each select="statistics/statistic">
                <xsl:sort select="@statement" />
                <tr HEIGHT='35' >
                  <td style='width:140'>
                    <span STYLE='position:relative;left:6px;'>
                      <xsl:value-of select="@statement"/>
                    </span>
                  </td>
                  <td align='right' style='width:55'>
                    <span STYLE='position:relative;right:6px;'>
                      <xsl:value-of select="@total"/>
                    </span>
                  </td>
                  <xsl:if test='@converted = 100'>
                    <td align='right' style='width:80'>
                      <span STYLE='position:relative;right:20px;'>
                        <xsl:value-of select="@converted"/>%
                      </span>
                    </td>
                  </xsl:if>
                  <xsl:if test='@converted &lt; 100'>
                    <!--
									<td align='right' style="width:75;font-size: 14px;color:red;font-weight:bold;">-->
                    <td align='right' style="width:80;">
                      <span STYLE='position:relative;right:6px;'>

                        <xsl:value-of select="@converted"/>%
                        <img STYLE='zoom:0.67;vertical-align:middle;' align='right' src='..\error.gif' />
                      </span>
                    </td>
                  </xsl:if>
                  <td align='right'  style='width:80'>
                    <span STYLE='position:relative;right:6px;'>
                      <xsl:value-of select="@not-converted-count"/>
                    </span>
                  </td>
                </tr>
              </xsl:for-each>
              </div>
            </table>

          </div>
        </td>
        </tr>
        </table>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
