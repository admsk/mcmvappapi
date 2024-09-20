import { useQuery } from "@tanstack/react-query";

export function useParticipants(scope = "IDOSO") {
  return useQuery({
    queryKey: ["participants", scope],
    queryFn: async () => {
      return await fetch(
        `${process.env.REACT_APP_BASEAPIURL}/Participantes/cota/${scope}`,
      ).then((r) => r.json());
    },
  });
}

export function useAllParticipants() {
  return useQuery({
    queryKey: ["participants"],
    queryFn: async () => {
      return await fetch(`${process.env.REACT_APP_BASEAPIURL}/Participantes/all`).then((r) =>
        r.json(),
      );
    },
  });
}

export function useSorteio() {
  return useQuery({
    queryKey: ["sorteio"],
    queryFn: async () => {
      const data = await fetch(
        `http://localhost:5094/Participantes/Sorteio`,
      ).then((r) => r.json());

      return data.reduce(
        (acc, participant) => {
          acc[participant.cota].push(participant);
          return acc;
        },
        { IDOSO: [], "DEFICIENTE FÍSICO": [], GERAL: [] },
      );
    },
  });
}
