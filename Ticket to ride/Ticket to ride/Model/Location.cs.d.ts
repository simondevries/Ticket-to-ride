declare module server {
	/** this dto is used for Connection -> location */
	interface LocationDto {
		identifier: string;
		x: number;
		y: number;
	}
	interface Location {
		associatedConnections: string[];
		identifier: string;
		width: number;
		y: number;
		x: number;
	}
	interface LocationEqualityComparer {
	}
}
