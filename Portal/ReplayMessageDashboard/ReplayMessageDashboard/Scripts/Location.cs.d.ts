declare module server {
	/** this dto is used for Connection -> location */
	interface LocationDto {
		identifier: string;
	}
	interface Location {
		AssociatedConnections: string[];
		Identifier: string;
		Width: number;
		Y: number;
		X: number;
	}
	interface LocationEqualityComparer {
	}
}
