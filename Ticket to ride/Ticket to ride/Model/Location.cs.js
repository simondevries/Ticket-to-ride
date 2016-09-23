var server = server || {};
/// <summary>this dto is used for Connection -&gt; location</summary>
server.LocationDto = function() {
	/// <field name="identifier" type="String">The Identifier property as defined in Ticket_to_ride.Model.LocationDto</field>
	this.identifier = '';
	/// <field name="x" type="Number">The X property as defined in Ticket_to_ride.Model.LocationDto</field>
	this.x = 0;
	/// <field name="y" type="Number">The Y property as defined in Ticket_to_ride.Model.LocationDto</field>
	this.y = 0;
};

/// <summary>The Location class as defined in Ticket_to_ride.Model.Location</summary>
server.Location = function() {
	/// <field name="associatedConnections" type="String[]">The AssociatedConnections property as defined in Ticket_to_ride.Model.Location</field>
	this.associatedConnections = [];
	/// <field name="identifier" type="String">The Identifier property as defined in Ticket_to_ride.Model.Location</field>
	this.identifier = '';
	/// <field name="width" type="Number">The Width property as defined in Ticket_to_ride.Model.Location</field>
	this.width = 0;
	/// <field name="y" type="Number">The Y property as defined in Ticket_to_ride.Model.Location</field>
	this.y = 0;
	/// <field name="x" type="Number">The X property as defined in Ticket_to_ride.Model.Location</field>
	this.x = 0;
};

/// <summary>The LocationEqualityComparer class as defined in Ticket_to_ride.Model.LocationEqualityComparer</summary>
server.LocationEqualityComparer = function() {
};

