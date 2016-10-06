declare module server {
	interface RouteCard {
		startLocation: {
			associatedConnections: string[];
			identifier: string;
			width: number;
			y: number;
			x: number;
		};
		endLocation: {
			associatedConnections: string[];
			identifier: string;
			width: number;
			y: number;
			x: number;
		};
		required: boolean;
		points: number;
	}
}
