declare module server {
	interface RouteCard {
		StartLocation: {
			AssociatedConnections: string[];
			Identifier: string;
			Width: number;
			Y: number;
			X: number;
		};
		EndLocation: {
			AssociatedConnections: string[];
			Identifier: string;
			Width: number;
			Y: number;
			X: number;
		};
		Required: boolean;
		Points: number;
	}
}
