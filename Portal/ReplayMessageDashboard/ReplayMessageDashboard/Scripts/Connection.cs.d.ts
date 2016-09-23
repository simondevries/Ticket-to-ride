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
        Owner: {
            HasFinished: boolean;
        };
        Identitity: string;
        Color: string;
        Selected: boolean;
        Risk: number;
        B: {
            AssociatedConnections: string[];
            Identifier: string;
            Width: number;
            Y: number;
            X: number;
        };
        A: {
            AssociatedConnections: string[];
            Identifier: string;
            Width: number;
            Y: number;
            X: number;
        };
        Weight: number;
        OriginalWeight: number;
    }
}
