import { OrbitControls } from '@react-three/drei';
import { Canvas } from '@react-three/fiber';
import { Suspense } from 'react';
import { Model } from './Model';

export function Canvas3D({ color }: { color: string; }) {
  return (
    <Canvas
      camera={{ position: [0, 0, 5], fov: 50 }}
      style={{ width: '1280px', height: '720px', background: '#111111ff' }}
    >
      <ambientLight intensity={Math.PI / 7} />
      <spotLight position={[10, 10, 10]} angle={0.15} penumbra={1} decay={0} intensity={Math.PI * 0.7} />
      <pointLight position={[-10, -10, -10]} decay={0} intensity={Math.PI * 0.7} />

      <Suspense fallback={null}>
        <Model position={[-1.2, -0.4, 0.25]} rotation={[1.66, 0.0, 0]} args={[]} color={color} />
      </Suspense>

      <OrbitControls enableDamping={false} />
    </Canvas>
  );
}
