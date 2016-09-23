declare module server {
	interface RouteCardDto {
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
	interface RouteCard {
	}
}
