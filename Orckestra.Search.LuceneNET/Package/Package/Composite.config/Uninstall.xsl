<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="@* | node()">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" />
		</xsl:copy>
	</xsl:template>

	<xsl:template match="/configuration/Composite.C1Console.Elements.Plugins.ElementProviderConfiguration/ElementProviderPlugins/add[@name='VirtualElementProvider']/Perspectives/add[@name='SearchPerspective']" />

</xsl:stylesheet>