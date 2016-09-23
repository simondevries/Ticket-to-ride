declare module server {
	interface ConnectionDto {
		owner: {
			hasFinished: boolean;
		};
		identitity: string;
		selected: boolean;
		risk: number;
		b: {
			identifier: string;
		};
		a: {
			identifier: string;
		};
		weight: number;
		color: string;
		originalWeight: number;
	}
	interface Connection {
		owner: {
			hasFinished: boolean;
		};
		identity: string;
		selected: boolean;
		risk: number;
		b: {
			associatedConnections: string[];
			identifier: string;
			width: number;
			y: number;
			x: number;
		};
		a: {
			associatedConnections: string[];
			identifier: string;
			width: number;
			y: number;
			x: number;
		};
		weight: number;
		originalWeight: number;
	}
}
