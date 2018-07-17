<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
<xsl:output method="text"/>
	<xsl:template match="/">
		<xsl:for-each select="xs:schema/xs:element">
			<xsl:if test="@msdata:IsDataSet = 'true'">
				<xsl:for-each select="xs:complexType">
          <xsl:for-each select="xs:choice">
            <xsl:for-each select="xs:element">
              <xsl:for-each select="xs:complexType">
                <xsl:for-each select="xs:sequence">
                  <xsl:for-each select="xs:element">
                    <xsl:value-of select="@msdata:DataType" /><xsl:value-of select="@name" />
                  </xsl:for-each>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:for-each>
          </xsl:for-each>
				</xsl:for-each>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>




<!-- Stylus Studio meta-information - (c)1998-2001 eXcelon Corp.
<metaInformation>
<scenarios ><scenario default="yes" name="Scenario1" userelativepaths="no" url="file://c:\Working\c#/TypedDataSetTest/ADONET.xsd" htmlbaseurl="" processortype="internal" commandline="" additionalpath="" additionalclasspath="" postprocessortype="none" postprocesscommandline="" postprocessadditionalpath="" postprocessgeneratedext=""/></scenarios><MapperInfo  srcSchemaPath="" srcSchemaRoot="" srcSchemaPathIsRelative="yes" destSchemaPath="" destSchemaRoot="" destSchemaPathIsRelative="yes" />
</metaInformation>
-->
