declare module server {
	interface PlayerTrainHandDto {
		trainDeckDto: {
			deck: number[];
			cardTypes: number[];
			faceUpCards: number[];
			discardPile: number[];
		};
		cards: number[];
	}
}
